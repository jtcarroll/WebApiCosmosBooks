using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiCosmosBooks.DTOs;
using WebApiCosmosBooks.Entities;
using WebApiCosmosBooks.Interfaces;

namespace WebApiCosmosBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookController
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet(Name = "GetBooks")]
        [Authorize(Policy = "api.read")]
        public async Task<IEnumerable<BookDto>> Get()
        {
            var books = await _bookService.GetBooks();
            return books;
        }

        [HttpPost(Name = "Book")]
        public async Task Post(CreateBookDto book)
        {
            await _bookService.CreateBookAsync(book);
        }

        [HttpPut]
        public async Task UpdateBookAsync([FromBody] BookDto bookDto)
        {
            await _bookService.UpdateBookAsync(bookDto);

        }

        [HttpDelete]
        public async Task DeleteBookAsync([FromBody] BookDto bookDto)
        {
            await _bookService.DeleteBookAsync(bookDto);

        }
    }
}
