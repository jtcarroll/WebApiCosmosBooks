using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCosmosBooks.Data;
using WebApiCosmosBooks.DTOs;
using WebApiCosmosBooks.Entities;
using WebApiCosmosBooks.Interfaces;

namespace WebApiCosmosBooks.Services
{
    public class BookService(LibraryContext context) : IBookService
    {
        [HttpPost]
        public async Task CreateBookAsync(CreateBookDto book)
        {
            var bookId = Guid.NewGuid();

            context.Add(
                new Book
                {
                    Id = bookId,
                    Authors = book.Authors,
                    NmPages = book.NmPages,
                    PartitionKey = bookId.ToString(),
                    Title = book.Title,
                });

            await context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = await context.Books.Where( x => x.Id == bookDto.Id && x.Title == bookDto.Title).FirstOrDefaultAsync();

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            book.Authors = bookDto.Authors;
            book.NmPages = bookDto.NmPages;
            book.Title = bookDto.Title;

            context.Books.Update(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(BookDto bookDto)
        {
            var book = await context.Books.Where(x => x.Id == bookDto.Id && x.Title == bookDto.Title).FirstOrDefaultAsync();

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            var books = await context.Books.ToListAsync();

            var bookDtos = books.ConvertAll(x => new BookDto
            {
                Title = x.Title,
                Authors = x.Authors,
                Id = x.Id,
                NmPages = x.NmPages,
            });

            return bookDtos;
        }
    }
}
