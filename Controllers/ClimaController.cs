using fiap.gerenciador_trafego.Services.Clima;
using fiap.gerenciador_trafego.ViewModel.Semaforo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        private readonly IClimaService _climaService;

        public ClimaController(IClimaService climaService)
        {
            _climaService = climaService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ClimaGetViewlModel>> GetAll()
        {
            var result = _climaService.GetAll();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public ActionResult<ClimaGetViewlModel> GetById(long id)
        {
            var result = _climaService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create([FromBody] ClimaCreateViewModel climaCreateViewModel)
        {
            var result = _climaService.Create(climaCreateViewModel);
            return CreatedAtAction(nameof(GetById), new { id = result.IdClima }, result);
        }

        [HttpPut("{id}")]
        public ActionResult<ClimaGetViewlModel> Update(long id, [FromBody] ClimaUpdateViewModel climaUpdateViewModel)
        {
            var result = _climaService.Update(id, climaUpdateViewModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<ClimaGetViewlModel> Delete(long id)
        {
            _climaService.DeleteById(id);
            return Ok();
        }
    }
}
