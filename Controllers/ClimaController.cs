using fiap.gerenciador_trafego.Services.Clima;
using fiap.gerenciador_trafego.ViewModel.Clima;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClimaController : ControllerBase
    {
        private readonly IClimaService _climaService;

        public ClimaController(IClimaService climaService)
        {
            _climaService = climaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClimaGetViewModel>> GetAll()
        {
            var climas = _climaService.GetAll();
            return Ok(climas);
        }

        [HttpGet("{id}")]
        public ActionResult<ClimaGetViewModel> GetById([FromRoute] int id)
        {
            var clima = _climaService.GetById(id);
            return Ok(clima);
        }

        [HttpPost]
        public ActionResult Create([FromBody] ClimaCreateViewModel climaCreateViewModel)
        {
            var clima = _climaService.Add(climaCreateViewModel);
            return CreatedAtAction(nameof(GetById), new { id = clima.id }, clima);
        }

        [HttpPut("{id}")]
        public ActionResult<ClimaGetViewModel> Update([FromRoute] int id, [FromBody]  ClimaUpdateViewModel climaUpdateViewModel)
        {
            var clima = _climaService.Update(id, climaUpdateViewModel);
            return Ok(clima);
        }

        [HttpDelete("{id}")]
        public ActionResult<ClimaGetViewModel> Delete([FromRoute] int id)
        {
            var clima = _climaService.DeleteById(id);
            return Ok(clima);
        }

    }
}
