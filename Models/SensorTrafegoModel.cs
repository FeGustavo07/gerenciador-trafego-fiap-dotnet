using System.ComponentModel.DataAnnotations.Schema;

namespace fiap.gerenciador_trafego.Models
{
    [Table("")]
    public class SensorTrafegoModel
    {
        private int id {  get; set; }
        private int qtFluxoVeiculos { get; set; }
        private int nrVisibilidade { get; set; }
        private DateOnly dtDeteccao { get; set; }
        private int semaforoId { get; set; }
        private SemaforoModel semaforo {  get; set; }
    }
}
