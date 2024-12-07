using fiap.gerenciador_trafego.Services;
using fiap.gerenciador_trafego.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
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
            _usuarioService.Add(usuarioCreateViewModel);
            return Created();
        }
    }
}
