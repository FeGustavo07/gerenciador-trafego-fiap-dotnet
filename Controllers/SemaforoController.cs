using fiap.gerenciador_trafego.Services.Semaforo;
using fiap.gerenciador_trafego.ViewModel.Semaforo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SemaforoController : ControllerBase
    {
        private readonly ISemaforoService _service;

        public SemaforoController(ISemaforoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SemaforoGetViewlModel>> GetAll() 
        {
            var semaforos = _service.GetAll();

            if (semaforos == null)
            {
                return NoContent();
            }

            return Ok(semaforos);
        }

        [HttpGet("{id}")]
        public ActionResult<SemaforoGetViewlModel> GetById([FromRoute] int id)
        {   
            var semaforo = _service.GetById(id);

            if (semaforo == null)
            {
                return NotFound();
            }

            return Ok(semaforo);
        }

        [HttpPost]
        public ActionResult Create([FromBody] SemaforoCreateViewModel semaforoCreateViewModel)
        {
            var semaforo = _service.Add(semaforoCreateViewModel);
            return CreatedAtAction(nameof(GetById), new { id = semaforo.idSemaforo }, semaforo);
        }

        [HttpPut("{id}")]
        public ActionResult<SemaforoGetViewlModel> Update([FromRoute] int id, [FromBody] SemaforoUpdateViewModel semaforoUpdateViewModel)
        {
            var semaforo = _service.Update(id, semaforoUpdateViewModel);
            return Ok(semaforo);
        }


        [HttpDelete("{id}")]
        public ActionResult<SemaforoGetViewlModel> Delete([FromRoute] int id)
        {
            var semaforo = _service.DeleteById(id);
            return Ok(semaforo);
        }

       
    }
}
