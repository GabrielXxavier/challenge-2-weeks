using Domain;
using LibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using LibraryWeb.DTOs;
using LibraryWeb.DTOs.BookDTOs;

namespace LibraryWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Book>> List()
        {
            return await _service.List();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            
            try
            {
                var response = await _service.Add(book);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book book)
        {
            try
            {
                var response = await _service.Update(book);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            try
            {
                var response = await _service.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
