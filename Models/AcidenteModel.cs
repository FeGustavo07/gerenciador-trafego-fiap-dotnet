using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fiap.gerenciador_trafego.Models
{
    public class AcidenteModel
    {
        [Key]
        [Column("id_reg_acidente")]
        public int IdRegAcidente { get; set; }

        [Column("ds_local_acidente")]
        [MaxLength(150)]
        public string DsLocalAcidente { get; set; }

        [Column("dt_acidente")]
        public DateTime DtAcidente { get; set; }

        [Column("ds_gravidade")]
        [MaxLength(10)]
        public string DsGravidade { get; set; }

        [Column("nr_fluxo_impactado")]
        public int NrFluxoImpactado { get; set; }

        [Column("t_gti_semaforo_id_semaforo")]
        public int? SemaforoId { get; set; }

        [ForeignKey("SemaforoId")]
        public SemaforoModel? Semaforo { get; set; }
    }
}
