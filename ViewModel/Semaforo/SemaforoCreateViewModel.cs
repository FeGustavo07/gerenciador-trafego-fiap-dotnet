using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Semaforo
{
    public class SemaforoCreateViewModel
    {
        [Required(ErrorMessage = "A localização é obrigatória")]
        public string dsLocalizacao { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public string dsEstado { get; set; }

        [Required(ErrorMessage = "Número de duração é obrigatório")]
        public int nmDuracaoEstado { get; set; }

        [Required(ErrorMessage = "A data de atualização é obrigatória")]
        public DateTime dtUltAtualizacao { get; set; }
        
        public long? ClimaId { get; set; }
    }
}
