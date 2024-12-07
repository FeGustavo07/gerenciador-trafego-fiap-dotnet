using fiap.gerenciador_trafego.Services.Rota;
using fiap.gerenciador_trafego.ViewModel.Clima;
using fiap.gerenciador_trafego.ViewModel.Rota;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RotaController : ControllerBase
    {
        private readonly IRotaService _rotaService;

        public RotaController(IRotaService rotaService)
        {
            _rotaService = rotaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RotaGetViewModel>> GetAll()
        {
            var rotas = _rotaService.GetAll();
            return Ok(rotas);
        }

        [HttpGet("{id}")]
        public ActionResult<RotaGetViewModel> GetById([FromRoute] int id)
        {
            var rota = _rotaService.GetById(id);
            return Ok(rota);
        }

        [HttpPost]
        public ActionResult Create([FromBody] RotaCreateViewModel rotaCreateViewModel)
        {
            var rota = _rotaService.Add(rotaCreateViewModel);
            return CreatedAtAction(nameof(GetById), new { id = rota.id }, rota);
        }

        [HttpPut("{id}")]
        public ActionResult<RotaGetViewModel> Update([FromRoute] int id, [FromBody] RotaUpdateViewModel rotaUpdateViewModel)
        {
            var rota = _rotaService.Update(id, rotaUpdateViewModel);
            return Ok(rota);
        }

        [HttpDelete("{id}")]
        public ActionResult<RotaGetViewModel> Delete([FromRoute] int id)
        {
            var rota = _rotaService.DeleteById(id);
            return Ok(rota);
        }
    }
}
