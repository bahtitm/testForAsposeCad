using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace ForAspose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class googleAuthController : ControllerBase
    {

        private readonly SignInManager<AppUser> _signInManager;
        public googleAuthController(SignInManager<AppUser> signInManager)
        {

            _signInManager = signInManager;
        }



        [HttpGet]
        public async void ExternalLoginCallback()
        {

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return;
           
           


            var claims = new List<Claim>();

            var userName = new Claim("UserName", info.Principal.Identity.Name);
            claims.Add(userName);
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,

                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(50)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = info.Principal.Identity.Name
            };            
           
            Response.Cookies.Append("token", JsonSerializer.Serialize(response));

            Response.Redirect("google.html");
        }
    }
}
