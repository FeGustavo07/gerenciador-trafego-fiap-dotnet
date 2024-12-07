using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.ViewModel.Acidente
{
    public class AcidenteGetViewModel
    {
        public int id { get; set; }
        public string localAcidente { get; set; }
        public DateOnly dataAcidente { get; set; }
        public string gravidade { get; set; }
        public int nmFluxoImpactado { get; set; }
        public SemaforoModel semaforo { get; set; }
    }
}
