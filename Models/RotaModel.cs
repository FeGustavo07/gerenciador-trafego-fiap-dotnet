using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fiap.gerenciador_trafego.Models
{
    public class RotaModel
    {
        [Key]
        [Column("id_rota")]
        public int IdRota { get; set; }

        [Column("ds_descricao_rota")]
        [MaxLength(200)]
        public string DsDescricaoRota { get; set; }

        [Column("ds_status")]
        [MaxLength(10)]
        public string DsStatus { get; set; } = "ABERTA";

        [Column("t_reg_acidente_id_reg_acidente")]
        public int? AcidenteId { get; set; }

        [ForeignKey("AcidenteId")]
        public AcidenteModel? Acidente { get; set; }
    }
}
