using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.ViewModel.SensorTrafego
{
    public class SensorTrafegoGetViewModel
    {
        public int id { get; set; }
        public int qtFluxoVeiculos { get; set; }
        public int nrVisibilidade { get; set; }
        public DateOnly dtDeteccao { get; set; }
        public int semaforoId { get; set; }
        public SemaforoModel semaforo { get; set; }
    }
}
