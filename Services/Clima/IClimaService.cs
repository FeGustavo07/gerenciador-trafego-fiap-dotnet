using fiap.gerenciador_trafego.ViewModel.Semaforo;

namespace fiap.gerenciador_trafego.Services.Clima;

public interface IClimaService
{
    IEnumerable<ClimaGetViewlModel> GetAll();
    ClimaGetViewlModel GetById(long id);
    ClimaGetViewlModel Create(ClimaCreateViewModel climaCreateViewModel);
    ClimaGetViewlModel Update(long id, ClimaUpdateViewModel climaUpdateViewModel);
    void DeleteById(long id);
}