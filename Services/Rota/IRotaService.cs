using fiap.gerenciador_trafego.ViewModel.Clima;
using fiap.gerenciador_trafego.ViewModel.Rota;

namespace fiap.gerenciador_trafego.Services.Rota
{
    public interface IRotaService
    {
        IEnumerable<RotaGetViewModel> GetAll();
        RotaGetViewModel GetById(int id);
        RotaGetViewModel Add(RotaCreateViewModel model);
        RotaGetViewModel Update(int id, RotaUpdateViewModel model);
        RotaGetViewModel DeleteById(int id);
    }
}
