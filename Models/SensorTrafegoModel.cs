using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fiap.gerenciador_trafego.Models
{
    [Table("t_gti_sensor_trafego")]
    public class SensorTrafegoModel
    {
        [Key]
        [Column("id_sensor")]
        public int IdSensor { get; set; }

        [Column("qt_fluxo_veiculos")]
        public int QtFluxoVeiculos { get; set; }

        [Column("nr_visibilidade")]
        public int NrVisibilidade { get; set; }

        [Column("dt_deteccao")]
        public DateTime DtDeteccao { get; set; }

        [Column("t_gti_semaforo_id_semaforo")]
        public int SemaforoId { get; set; }

        [ForeignKey("SemaforoId")]
        public SemaforoModel Semaforo { get; set; }
    }
}
