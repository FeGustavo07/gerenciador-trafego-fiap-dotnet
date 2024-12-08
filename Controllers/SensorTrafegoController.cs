using fiap.gerenciador_trafego.Services.SensorTrafego;
using fiap.gerenciador_trafego.ViewModel.Acidente;
using fiap.gerenciador_trafego.ViewModel.SensorTrafego;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "desenvolvedor,avaliador")]
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
            IEnumerable<SensorTrafegoGetViewModel> sensores;

            try
            {
                sensores = _sensorTrafegoService.GetAll();
                return Ok(sensores);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SensorTrafegoGetViewModel> GetById([FromRoute] int id)
        {
            SensorTrafegoGetViewModel sensor;

            try
            {
                sensor = _sensorTrafegoService.GetById(id);
                return Ok(sensor);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] SensorTrafegoCreateViewModel sensorTrafegoCreateViewModel)
        {
            SensorTrafegoGetViewModel sensor;

            try
            {
                sensor = _sensorTrafegoService.Add(sensorTrafegoCreateViewModel);
                return CreatedAtAction(nameof(GetById), new { id = sensor.id }, sensor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<SensorTrafegoGetViewModel> Update([FromRoute] int id, [FromBody] SensorTrafegoUpdateViewlModel sensorTrafegoUpdateViewlModel)
        {
            SensorTrafegoGetViewModel sensor;

            try
            {
                sensor = _sensorTrafegoService.Update(id, sensorTrafegoUpdateViewlModel);
                return Ok(sensor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<SensorTrafegoGetViewModel> Delete([FromRoute] int id)
        {
            try
            {
                _sensorTrafegoService.DeleteById(id);
                return Ok(new { Message = "Operação concluída com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }
    }
}
