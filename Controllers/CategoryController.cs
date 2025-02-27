using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursesApi.Interfaces;

namespace OnlineCoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("categories")]
        [Authorize]
        public async Task<IActionResult> GetAllCategories()
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var categories = await _repository.GetAllCategoriesAsync();

            if(categories == null){
                return NotFound();
            }

            return Ok(categories);
        }
    }
}