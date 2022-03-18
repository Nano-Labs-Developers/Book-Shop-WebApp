using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BookTypeController : ControllerBase
    {
        private readonly IBookTypeService _bookTypeService;

        public BookTypeController(IBookTypeService bookTypeService)
        {
            _bookTypeService = bookTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BookType>>>> GetBookTypes()
        {
            var response = await _bookTypeService.GetBookTypes();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<BookType>>>> AddBookType(BookType productType)
        {
            var response = await _bookTypeService.AddBookType(productType);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<BookType>>>> UpdateBookType(BookType productType)
        {
            var response = await _bookTypeService.UpdateBookType(productType);
            return Ok(response);
        }
    }
}
