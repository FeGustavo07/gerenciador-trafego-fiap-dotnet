using fiap.gerenciador_trafego.Services.Rota;
using fiap.gerenciador_trafego.ViewModel.Acidente;
using fiap.gerenciador_trafego.ViewModel.Clima;
using fiap.gerenciador_trafego.ViewModel.Rota;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fiap.gerenciador_trafego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "desenvolvedor,avaliador")]
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
            IEnumerable<RotaGetViewModel> rotas;

            try
            {
                rotas = _rotaService.GetAll();
                return Ok(rotas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RotaGetViewModel> GetById([FromRoute] int id)
        {
            RotaGetViewModel rota;

            try
            {
                rota = _rotaService.GetById(id);
                return Ok(rota);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] RotaCreateViewModel rotaCreateViewModel)
        {
            RotaGetViewModel rota;

            try
            {
                rota = _rotaService.Add(rotaCreateViewModel);
                return CreatedAtAction(nameof(GetById), new { id = rota.id }, rota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<RotaGetViewModel> Update([FromRoute] int id, [FromBody] RotaUpdateViewModel rotaUpdateViewModel)
        {
            RotaGetViewModel rota;

            try
            {
                rota = _rotaService.Update(id, rotaUpdateViewModel);
                return Ok(rota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<RotaGetViewModel> Delete([FromRoute] int id)
        {
            try
            {
                _rotaService.DeleteById(id);
                return Ok(new { Message = "Operação concluída com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An internal server error occurred.", Details = ex.Message });
            }
        }
    }
}
