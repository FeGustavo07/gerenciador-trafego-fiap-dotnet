using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel.Semaforo;

namespace fiap.gerenciador_trafego.Services.Semaforo
{
    public interface ISemaforoService
    {
        IEnumerable<SemaforoGetViewlModel> GetAll();
        SemaforoGetViewlModel GetById(int id);
        SemaforoGetViewlModel Add(SemaforoCreateViewModel model);
        SemaforoGetViewlModel Update(int id, SemaforoUpdateViewModel model);
        void DeleteById(int id);
    }
}
