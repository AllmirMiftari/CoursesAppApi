using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursesApi.Data;
using OnlineCoursesApi.Helpers;
using OnlineCoursesApi.Interfaces;

namespace OnlineCoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController: ControllerBase
    {
        private readonly ICourseRepository _repository;
        private readonly ApplicationDbContext _context;

        public CourseController(ICourseRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet("courses")]
        [Authorize]
        public async Task<IActionResult> GetAllCourses(){

            var courses = await _repository.GetAllCoursesAsync(); 

            return Ok(courses);
        
        }

        [HttpGet("coursesByCategory/{name}")]
        [Authorize]
        public async Task<IActionResult> GetCoursesByCategory([FromRoute] string name)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var courses = await _repository.GetCoursesByCategoryAsync(name);

            if(courses == null){
                return NotFound();
            }

            return Ok(courses);
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> GetFilteredCourses([FromQuery] QueryObject query){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var courses = await _repository.GetFilteredCoursesAsync(query);

            return Ok(courses);

        }

        [HttpGet ("{courseId}")]
        [Authorize]
        public async Task<IActionResult> GetCourseById([FromRoute] int courseId){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var course = await _repository.GetCourseByIdAsync(courseId);

            return Ok(course);
        }

    }
}