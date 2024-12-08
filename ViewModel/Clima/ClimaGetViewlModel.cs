using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Semaforo
{
    public class ClimaGetViewlModel
    {
        public long IdClima { get; set; }
        public string DsCondicao { get; set; }
        public double NrTemperatura { get; set; }
        public double NrUmidade { get; set; }
        public DateTime DtRegistro { get; set; }
    }
}
