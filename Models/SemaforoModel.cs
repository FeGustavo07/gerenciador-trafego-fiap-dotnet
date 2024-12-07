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
        private int id { get; set; }
        private string dsLocalizacao { get; set; }
        private string deEstado { get; set; }
        private int nrDuracaoEstado { get; set; }
        private DateOnly dtUltAtualizacao { get; set; }
    }
}
