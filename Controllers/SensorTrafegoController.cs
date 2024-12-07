using fiap.gerenciador_trafego.Services.SensorTrafego;
using fiap.gerenciador_trafego.ViewModel.SensorTrafego;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SensorTrafegoController : ControllerBase
    {
        private readonly ISensorTrafegoService _sensorTrafegoService;

        public SensorTrafegoController(ISensorTrafegoService sensorTrafegoService)
        {
            _sensorTrafegoService = sensorTrafegoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SensorTrafegoGetViewModel>> GetAll()
        {
            var sensorTrafego = _sensorTrafegoService.GetAll();

            if (sensorTrafego == null)
            {
                return NoContent();
            }

            return Ok(sensorTrafego);
        }

        [HttpGet("{id}")]
        public ActionResult<SensorTrafegoGetViewModel> GetById([FromRoute] int id)
        {
            var sensorTrafego = _sensorTrafegoService.GetById(id);

            if (sensorTrafego == null)
            {
                return NotFound();
            }

            return Ok(sensorTrafego);
        }

        [HttpPost]
        public ActionResult Create([FromBody] SensorTrafegoCreateViewModel sensorTrafegoCreateViewModel)
        {
            var sensorTrafego = _sensorTrafegoService.Add(sensorTrafegoCreateViewModel);
            return CreatedAtAction(nameof(GetById), new { id = sensorTrafego.id }, sensorTrafego);
        }

        [HttpPut("{id}")]
        public ActionResult<SensorTrafegoGetViewModel> Update([FromRoute] int id, [FromBody] SensorTrafegoUpdateViewlModel sensorTrafegoUpdateViewlModel)
        {
            var sensorTrafego = _sensorTrafegoService.Update(id, sensorTrafegoUpdateViewlModel);
            return Ok(sensorTrafego);
        }


        [HttpDelete("{id}")]
        public ActionResult<SensorTrafegoGetViewModel> Delete([FromRoute] int id)
        {
            var sensorTrafego = _sensorTrafegoService.DeleteById(id);
            return Ok(sensorTrafego);
        }
    }
}
