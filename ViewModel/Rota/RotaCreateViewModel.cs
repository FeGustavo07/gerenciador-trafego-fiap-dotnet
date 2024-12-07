using fiap.gerenciador_trafego.Models;
using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Rota
{
    public class RotaCreateViewModel
    {
        [Required(ErrorMessage = "A descrição da rota é obrigatória")]
        public string descricaoRota { get; set; }

        [Required(ErrorMessage = "Status deve ser 'ABERTA' ou 'FECHADA'")]
        public string status { get; set; }

        [Required(ErrorMessage = "O id do acidente é obrigatório")]
        public int acidenteId { get; set; }
    }
}
