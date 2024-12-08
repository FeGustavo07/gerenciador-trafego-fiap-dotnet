using fiap.gerenciador_trafego.Services.Semaforo;
using fiap.gerenciador_trafego.ViewModel.Acidente;
using fiap.gerenciador_trafego.ViewModel.Semaforo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "desenvolvedor,avaliador")]
    public class SemaforoController : ControllerBase
    {
        private readonly ISemaforoService _semaforoService;

        public SemaforoController(ISemaforoService service)
        {
            _semaforoService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SemaforoGetViewlModel>> GetAll() 
        {
            IEnumerable<SemaforoGetViewlModel> semaforos;

            try
            {
                semaforos = _semaforoService.GetAll();
                return Ok(semaforos);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SemaforoGetViewlModel> GetById([FromRoute] int id)
        {
            SemaforoGetViewlModel semaforo;

            try
            {
                semaforo = _semaforoService.GetById(id);
                return Ok(semaforo);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        
        public ActionResult Create([FromBody] SemaforoCreateViewModel semaforoCreateViewModel)
        {
            SemaforoGetViewlModel semaforo;

            try
            {
                semaforo = _semaforoService.Add(semaforoCreateViewModel);
                return CreatedAtAction(nameof(GetById), new { id = semaforo.idSemaforo }, semaforo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<SemaforoGetViewlModel> Update([FromRoute] int id, [FromBody] SemaforoUpdateViewModel semaforoUpdateViewModel)
        {
            SemaforoGetViewlModel semaforo;

            try
            {
                semaforo = _semaforoService.Update(id, semaforoUpdateViewModel);
                return Ok(semaforo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<SemaforoGetViewlModel> Delete([FromRoute] int id)
        {
            try
            {
                _semaforoService.DeleteById(id);
                return Ok(new { Message = "Operação concluída com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

       
    }
}
