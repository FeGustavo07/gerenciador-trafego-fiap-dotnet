using fiap.gerenciador_trafego.Services;
using fiap.gerenciador_trafego.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] UsuarioCreateViewModel usuarioCreateViewModel)
        {
            try
            {
                _usuarioService.Add(usuarioCreateViewModel);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }
    }
}
