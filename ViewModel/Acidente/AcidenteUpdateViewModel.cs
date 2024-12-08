using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Acidente
{
    public class AcidenteUpdateViewModel
    {
        [Required(ErrorMessage = "O local do acidente é obrigatório")]
        public string localAcidente { get; set; }

        [Required(ErrorMessage = "A data do acidente é obrigatória")]
        public DateTime dataAcidente { get; set; }

        [Required(ErrorMessage = "A gravidade do acidente é obrigatória")]
        public string gravidade { get; set; }

        [Required(ErrorMessage = "O número do fluxo impactado é obrigatório")]
        public int nmFluxoImpactado { get; set; }

        [Required(ErrorMessage = "O id do semáforo é obrigatório")]
        public int semaforoId { get; set; }
    }
}
