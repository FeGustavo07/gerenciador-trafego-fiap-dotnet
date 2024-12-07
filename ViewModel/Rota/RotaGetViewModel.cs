using fiap.gerenciador_trafego.Models;
using System.ComponentModel.DataAnnotations;

namespace fiap.gerenciador_trafego.ViewModel.Rota
{
    public class RotaGetViewModel
    {
        public int id { get; set; }
        public string descricaoRota { get; set; }
        public string status { get; set; }
        public AcidenteModel acidente { get; set; }
    }
}
