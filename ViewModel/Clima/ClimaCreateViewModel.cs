using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Clima
{
    public class ClimaCreateViewModel
    {
        [Required(ErrorMessage = "A descrição da condição é obrigatória")]
        public string dsCondicao { get; set; }
        [Required(ErrorMessage = "O número da temperatura é obrigatório")]
        public double nrTemperatura { get; set; }
        [Required(ErrorMessage = "O número da umidade é obrigatório")]
        public double nrUmidade { get; set; }
        [Required(ErrorMessage = "A data é obrigatória")]
        public DateOnly dtRegistro { get; set; }
    }
}
