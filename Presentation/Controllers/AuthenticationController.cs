using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Users.Queries.GetAllUserPermission;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace Medicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] GetAllUserPermissionQuery command)
        {
            var permissions = await mediator.Send(command);
            if (permissions == null) return BadRequest();
            var claims = new List<Claim>();
            foreach (var item in permissions)
            {
                var claim = new Claim(item.ClaimType.ToString(), item.ClaimValue.ToString());
                claims.Add(claim);

            }
            var userName = new Claim("UserName", command.Name);
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
                username = command.Name
            };

            return Ok(response);
        }
    }
}
