using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel.Clima;

namespace fiap.gerenciador_trafego.Services.Clima
{
    public interface IClimaService
    {
        IEnumerable<ClimaGetViewModel> GetAll();
        ClimaGetViewModel GetById(long id);
        ClimaGetViewModel Add(ClimaCreateViewModel model);
        ClimaGetViewModel Update(long id, ClimaUpdateViewModel model);
        void DeleteById(long id);
    }
}
