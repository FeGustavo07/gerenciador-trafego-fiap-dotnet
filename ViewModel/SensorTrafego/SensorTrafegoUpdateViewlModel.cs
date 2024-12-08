using fiap.gerenciador_trafego.Models;
using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.SensorTrafego
{
    public class SensorTrafegoUpdateViewlModel
    {
        [Required(ErrorMessage = "O número de fluxo de veículos é obrigatório")]
        public int qtFluxoVeiculos { get; set; }

        [Required(ErrorMessage = "A visibilidade é obrigatória")]
        public int nrVisibilidade { get; set; }

        [Required(ErrorMessage = "A data de detecção é obrigatória")]
        public DateTime dtDeteccao { get; set; }    

        [Required(ErrorMessage = "O id do semaforo é obrigatório")]
        public int semaforoId { get; set; }
    }
}
