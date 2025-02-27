using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursesApi.Extensions;
using OnlineCoursesApi.Interfaces;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController: ControllerBase
    {
        
        private readonly UserManager<User> _userManager;
        private readonly ICourseRepository _courseRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationController(UserManager<User> userManager,
        ICourseRepository courseRepository,
        IRegistrationRepository registrationRepository)
        {
            _userManager = userManager;
            _courseRepository = courseRepository;
            _registrationRepository = registrationRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserRegistrations()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userRegistration  = await _registrationRepository.GetUserRegistration(appUser);
            return Ok(userRegistration);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRegistration([FromBody] int courseid){

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var course = await _courseRepository.GetCourseByIdAsync(courseid);

            if(course == null) return BadRequest("course not found!");

            var userRegistration = await _registrationRepository.GetUserRegistration(appUser);

            if(userRegistration.Any(c => c.CourseId == courseid)) return BadRequest("cannot register the same course twice!");

            var registrationModel = new Registration{
                CourseId = courseid,
                UserId = appUser.Id
            };

            await _registrationRepository.CreateRegistration(registrationModel);

            if(registrationModel == null){
                return StatusCode(500, "could not register");
            }else{
                return Created();
            }

        }

        [HttpDelete ("{courseid}")]
        [Authorize]
        public async Task<IActionResult> DeleteRegistration([FromRoute] int courseid){
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userRegistration = await _registrationRepository.GetUserRegistration(appUser);

            var filteredCourses = userRegistration.Where(c => c.CourseId == courseid).ToList();

            if(filteredCourses.Count() == 1){

                await _registrationRepository.DeleteRegistration(appUser, courseid);

            }else {
                return BadRequest("you have not registered this course yet!");
            }

            return Ok();
        }

    }
}