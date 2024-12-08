using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace fiap.gerenciador_trafego.Models
{
    [Table("t_gti_semaforo")]
    public class SemaforoModel
    {
        [Key]
        [Column("id_semaforo")]
        public int IdSemaforo { get; set; }

        [Column("ds_localizacao")]
        [MaxLength(150)]
        public string DsLocalizacao { get; set; }

        [Column("ds_estado")]
        [MaxLength(10)]
        public string DsEstado { get; set; } = "vermelho";

        [Column("nr_duracao_estado")]
        public int NrDuracaoEstado { get; set; }

        [Column("dt_ult_atualizacao")]
        public DateTime DtUltAtualizacao { get; set; }

        [Column("t_gti_clima_id_clima")]
        public long? ClimaId { get; set; }

        [ForeignKey("ClimaId")]
        public ClimaModel? Clima { get; set; }
    }
}
