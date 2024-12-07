using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel.Clima;

namespace fiap.gerenciador_trafego.Services.Clima
{
    public interface IClimaService
    {
        IEnumerable<ClimaGetViewModel> GetAll();
        ClimaGetViewModel GetById(int id);
        ClimaGetViewModel Add(ClimaCreateViewModel model);
        ClimaGetViewModel Update(int id, ClimaUpdateViewModel model);
        ClimaGetViewModel DeleteById(int id);
    }
}
