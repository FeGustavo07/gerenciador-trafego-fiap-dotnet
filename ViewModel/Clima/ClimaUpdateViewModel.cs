using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Semaforo
{
    public class ClimaUpdateViewModel
    {
        [Required(ErrorMessage = "O campo 'DS_CONDICAO' é obrigatório!")]
        [StringLength(150, ErrorMessage = "O campo 'DS_CONDICAO' deve ter no máximo 150 caracteres.")]
        public string DsCondicao { get; set; }

        [Required(ErrorMessage = "O campo 'NrTemperatura' é obrigatório.")]
        public double NrTemperatura { get; set; }

        [Required(ErrorMessage = "O campo 'NrUmidade' é obrigatório.")]
        public double NrUmidade { get; set; }

        [Required(ErrorMessage = "O campo 'DtRegistro' é obrigatório.")]
        public DateTime DtRegistro { get; set; }
    }
}