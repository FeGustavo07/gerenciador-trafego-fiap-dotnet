using fiap.gerenciador_trafego.ViewModel.Acidente;
using fiap.gerenciador_trafego.ViewModel.Clima;

namespace fiap.gerenciador_trafego.Services.Acidente
{
    public interface IAcidenteService
    {
        IEnumerable<AcidenteGetViewModel> GetAll();
        AcidenteGetViewModel GetById(int id);
        AcidenteGetViewModel Add(AcidenteCreateViewModel model);
        AcidenteGetViewModel Update(int id, AcidenteUpdateViewModel model);
        void DeleteById(int id);
    }
}
