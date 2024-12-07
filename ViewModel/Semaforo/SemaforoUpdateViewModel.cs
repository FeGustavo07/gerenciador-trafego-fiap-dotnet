using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Semaforo
{
    public class SemaforoUpdateViewModel
    {
        [Required(ErrorMessage = "A localização é obrigatória")]
        private string dsLocalizacao { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        private string dsEstado { get; set; }

        [Required(ErrorMessage = "Número de duração é obrigatório")]
        private int nmDuracaoEstado { get; set; }

        [Required(ErrorMessage = "A data de atualização é obrigatória")]
        private DateOnly dtUltAtualizacao { get; set; }
    }
}
