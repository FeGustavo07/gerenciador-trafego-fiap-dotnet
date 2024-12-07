namespace fiap.gerenciador_trafego.Models
{
    public class AcidenteModel
    {
        private int id {  get; set; }
        private string localAcidente { get; set; }
        private DateOnly dataAcidente { get; set; }
        private string gravidade {  get; set; }
        private int nmFluxoImpactado { get; set; }
        private int semaforoId { get; set; }
        private SemaforoModel semaforo { get; set; }
    }
}
