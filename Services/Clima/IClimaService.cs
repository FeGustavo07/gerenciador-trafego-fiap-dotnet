using fiap.gerenciador_trafego.ViewModel.Clima;

namespace fiap.gerenciador_trafego.Services.Clima;

public interface IClimaService
{
    IEnumerable<ClimaGetViewModel> GetAll();
    ClimaGetViewModel GetById(long id);
    ClimaGetViewModel Create(ClimaCreateViewModel climaCreateViewModel);
    ClimaGetViewModel Update(long id, ClimaUpdateViewModel climaUpdateViewModel);
    void DeleteById(long id);
}