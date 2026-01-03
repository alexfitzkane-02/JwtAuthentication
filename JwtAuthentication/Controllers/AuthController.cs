using JwtAuthentication.Models.DTO;
using JwtAuthentication.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        //Create Constructor to inject UserManager. It will be of type IdentityUser
        public AuthController(UserManager<IdentityUser> userManager,
            ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDto.Email?.Trim(),
                Email = registerRequestDto.Email?.Trim()
            };

            //Create User in Database
            var identityResult = await userManager.CreateAsync(user, registerRequestDto.Password);
            if (identityResult.Succeeded)
            {
                //Add Role To User
                identityResult = await userManager.AddToRoleAsync(user, "Reader");
                if (identityResult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            else
            {
                if (identityResult.Errors.Any())
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            //check if email exsits 
            var identityUser = await userManager.FindByEmailAsync(loginRequestDto.Email);

            
            if (identityUser is not null)
            {
                //check if password is corecct
                var checkPassword = await userManager.CheckPasswordAsync(identityUser, loginRequestDto.Password);

                if (checkPassword)
                {
                    //grab roles for user
                    var roles = await userManager.GetRolesAsync(identityUser);

                    //create jwt token and return response
                    var jwtToken = tokenRepository.CreateJwtToken(identityUser, roles.ToList());

                    var response = new LoginResponseDto
                    {
                        Email = identityUser.Email,
                        Roles = roles.ToList()
                    };

                    Response.Cookies.Append("access_token", jwtToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Lax,
                        Expires = DateTime.UtcNow.AddMinutes(30)
                    });

                    return Ok(response);
                }
            }

            ModelState.AddModelError("", "Email or Password is Incorrect");

            return ValidationProblem(ModelState);
        }
    }
}
