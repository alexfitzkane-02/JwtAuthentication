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

        //Create Constructor to inject UserManager. It will be of type IdentityUser
        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

    }
}
