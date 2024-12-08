using fiap.gerenciador_trafego.Services;
using fiap.gerenciador_trafego.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginViewModel usuario)
        {
            UsuarioGetViewModel autheticatedUser;
            try
            {
                autheticatedUser = _authService.Authenticate(usuario);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(autheticatedUser);
            return Ok(new { token = token });
        }

        private string GenerateJwtToken(UsuarioGetViewModel usuario)
        {
            byte[] secret = Encoding.ASCII.GetBytes("f57fd9bbe041d379720eec80199cee4ec2d9a7a7800f486baec2711de5651208b6153bf41028d9d56ff3f1666df9803a83296a37eb8087aee70d313004345e0c32d91784a46dabef8cc88c13a180e0909798c796659d950266047dda28f95b20e14bf72032ea423f657393654f9e33af3e53e65110d5e6027bfdf55f5a5378");
            var securityKey = new SymmetricSecurityKey(secret);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim(ClaimTypes.Role, usuario.Role),
                    new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = "fiap",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }


    }
}
