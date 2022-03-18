using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            var result = await _bookService.GetBookAsync();
			return Ok(result);
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<ServiceResponse<Book>>> GetBook(int bookId)
        {
            var result = await _bookService.GetBookAsync(bookId);
            return Ok(result);
        }

        [HttpGet("category/{categoryURL}")]
        public async Task<ActionResult<ServiceResponse<Book>>> GetBooksbyCategory(string categoryURL)
        {
            var result = await _bookService.GetBooksbyCategory(categoryURL);
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetAdminBooks()
        {
            var result = await _bookService.GetAdminBooks();
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Book>>> CreateBook(Book book)
        {
            var result = await _bookService.CreateBook(book);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Book>>> UpdateBook(Book book)
        {
            var result = await _bookService.UpdateBook(book);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);
            return Ok(result);
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<BookSearchResult>>> SearchProducts(string searchText, int page = 1)
        {
            var result = await _bookService.SearchBooks(searchText, page);
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _bookService.GetBookSearchSuggestions(searchText);
            return Ok(result);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetFeaturedProducts()
        {
            var result = await _bookService.GetFeaturedBooks();
            return Ok(result);
        }
    }
}
