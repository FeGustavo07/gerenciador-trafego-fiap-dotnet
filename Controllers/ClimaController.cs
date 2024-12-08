using fiap.gerenciador_trafego.Services.Clima;
using fiap.gerenciador_trafego.ViewModel.Clima;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "desenvolvedor,avaliador")]
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
            IEnumerable<ClimaGetViewModel> climas;

            try
            {
                climas = _climaService.GetAll();
                return Ok(climas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            
           
        }

        [HttpGet("{id}")]
        public ActionResult<ClimaGetViewModel> GetById([FromRoute] int id)
        {
            ClimaGetViewModel clima;

            try
            {
                clima = _climaService.GetById(id);
                return Ok(clima);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult Create([FromBody] ClimaCreateViewModel climaCreateViewModel)
        {
            ClimaGetViewModel clima;

            try
            {
                clima = _climaService.Add(climaCreateViewModel);
                return CreatedAtAction(nameof(GetById), new { id = clima.id }, clima);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }

        }

        [HttpPut("{id}")]
        public ActionResult<ClimaGetViewModel> Update([FromRoute] int id, [FromBody]  ClimaUpdateViewModel climaUpdateViewModel)
        {
            ClimaGetViewModel clima;

            try
            {
                clima = _climaService.Update(id, climaUpdateViewModel);
                return Ok(clima);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                _climaService.DeleteById(id);
                return Ok(new { Message = "Operação concluída com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

    }
}
