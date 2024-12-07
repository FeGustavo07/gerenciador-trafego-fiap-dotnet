using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.Semaforo
{
    public interface ISemaforoRepository
    {
        IEnumerable<SemaforoModel> GetAll();
        SemaforoModel GetById(int id);
        SemaforoModel Add(SemaforoModel model);
        SemaforoModel Update(SemaforoModel model);
        void DeleteById(SemaforoModel model);

    }
}
