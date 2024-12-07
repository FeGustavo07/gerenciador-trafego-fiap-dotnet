using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Clima
{
    public class ClimaGetViewModel
    {
        public int id { get; set; }
        public string dsCondicao { get; set; }
        public double nrTemperatura { get; set; }
        public double nrUmidade { get; set; }
        public DateOnly dtRegistro { get; set; }
    }
}
