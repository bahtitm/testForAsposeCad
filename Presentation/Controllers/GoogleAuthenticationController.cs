using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ForAspose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleAuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly SignInManager<AppUser> _signInManager;
        public GoogleAuthenticationController(IMediator mediator, SignInManager<AppUser> signInManager)
        {
            this.mediator = mediator;
            _signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalLogin()
        {            
            var returnUrl = "https://localhost:7107/api/googleAuth";
            string provider = "Google"; _signInManager.GetExternalAuthenticationSchemesAsync();            
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, returnUrl);
            return Challenge(properties, provider);
        }

    }
}
