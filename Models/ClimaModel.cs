using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fiap.gerenciador_trafego.Models;

public class ClimaModel
{
    public long IdClima { get; set; }
    public string DsCondicao { get; set; }
    public double NrTemperatura { get; set; }
    public double NrUmidade { get; set; }
    public DateTime DtRegistro { get; set; }
}