using WebApiCosmosBooks.DTOs;

namespace WebApiCosmosBooks.Interfaces
{
    public interface IBookService
    {
        Task CreateBookAsync(CreateBookDto book);
        Task<IEnumerable<BookDto>> GetBooks();

        Task UpdateBookAsync(BookDto bookDto);
        Task DeleteBookAsync(BookDto bookDto);
    }
}
