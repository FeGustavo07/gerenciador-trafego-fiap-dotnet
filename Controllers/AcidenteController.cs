using fiap.gerenciador_trafego.Services.Acidente;
using fiap.gerenciador_trafego.ViewModel.Acidente;
using fiap.gerenciador_trafego.ViewModel.Clima;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "desenvolvedor,avaliador")]
    public class AcidenteController : ControllerBase
    {
        private readonly IAcidenteService _acidenteService;

        public AcidenteController(IAcidenteService acidenteService)
        {
            _acidenteService = acidenteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AcidenteGetViewModel>> GetAll()
        {
            IEnumerable<AcidenteGetViewModel> acidentes;

            try
            {
                acidentes = _acidenteService.GetAll();
                return Ok(acidentes);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<AcidenteGetViewModel> GetById([FromRoute] int id)
        {
            AcidenteGetViewModel acidente;

            try
            {
                acidente = _acidenteService.GetById(id);
                return Ok(acidente);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult Create([FromBody] AcidenteCreateViewModel acidenteCreateViewModel)
        {
            AcidenteGetViewModel acidente;

            try
            {
                acidente = _acidenteService.Add(acidenteCreateViewModel);
                return CreatedAtAction(nameof(GetById), new { id = acidente.id }, acidente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
           
        }

        [HttpPut("{id}")]
        public ActionResult<ClimaGetViewModel> Update([FromRoute] int id, [FromBody] AcidenteUpdateViewModel acidenteUpdateViewModel)
        {
            AcidenteGetViewModel acidente;

            try
            {
                acidente = _acidenteService.Update(id, acidenteUpdateViewModel);
                return Ok(acidente);
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
                _acidenteService.DeleteById(id);
                return Ok(new { Message = "Operação concluída com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }

        }
    }
}
