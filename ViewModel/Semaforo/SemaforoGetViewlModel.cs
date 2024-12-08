using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Semaforo
{
    public class SemaforoGetViewlModel
    {
        public int idSemaforo { get; set; }
        public string dsLocalizacao { get; set; }
        public string dsEstado { get; set; }
        public int nmDuracaoEstado { get; set; }
        public DateTime dtUltAtualizacao { get; set; }
    }
}
