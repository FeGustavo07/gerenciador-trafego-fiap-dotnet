namespace fiap.gerenciador_trafego.Models
{
    public class ClimaModel
    {
        private int id {  get; set; }
        private string dsCondicao { get; set; }
        private double nrTemperatura { get; set; }
        private double nrUmidade { get; set; }
        private DateOnly dtRegistro { get; set; }
        private ICollection<SemaforoModel> Semaforos { get; set; }

    }
}
