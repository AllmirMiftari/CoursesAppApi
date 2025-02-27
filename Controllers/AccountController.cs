using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesApi.Dto.Account;
using OnlineCoursesApi.Interfaces;
using OnlineCoursesApi.Models;

namespace OnlineCoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,
         IConfiguration configuration, ITokenService tokenService,
         SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {

            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                var user = new User
                {
                    Email = registerDto.Email,
                    UserName = registerDto.Username,
                };

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                Username = user.UserName,
                                Email = user.Email,
                                token = _tokenService.CreateToken(user)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, new { succeeded = false, errors = roleResult.Errors });
                    }
                }
                else
                {
                    return StatusCode(500, new { succeeded = false, errors = createdUser.Errors });
                }


            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized("invalid email!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("email or password incorrect!");

            return Ok(
                 new NewUserDto
                 {
                    Username = user.UserName,
                    Email = user.Email,
                    token = _tokenService.CreateToken(user)
                 }
            );
        }
    }
}