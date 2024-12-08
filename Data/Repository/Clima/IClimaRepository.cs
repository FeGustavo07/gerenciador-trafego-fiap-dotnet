using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.Clima;

public interface IClimaRepository
{
    IEnumerable<ClimaModel> GetAll();
    ClimaModel GetById(long id);
    ClimaModel Add(ClimaModel model);
    ClimaModel Update(ClimaModel model);
    void Delete(ClimaModel model);
}