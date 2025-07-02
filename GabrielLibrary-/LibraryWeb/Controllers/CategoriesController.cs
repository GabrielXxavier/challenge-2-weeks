using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Interfaces;

namespace LibraryWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;

        }

        [HttpGet]
        public async Task<List<Category>> List()
        {
            return await _service.List();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Category category)
        {
            return Ok(await _service.Add(category));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Category category)
        {
            return Ok(await _service.Update(category));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
