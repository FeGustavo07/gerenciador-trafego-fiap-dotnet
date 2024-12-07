using fiap.gerenciador_trafego.Services;
using fiap.gerenciador_trafego.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
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
            byte[] secret = Encoding.ASCII.GetBytes(_configuration["EncryptionKey"]);
            var securityKey = new SymmetricSecurityKey(secret);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.username),
                    new Claim(ClaimTypes.Role, usuario.role),
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
