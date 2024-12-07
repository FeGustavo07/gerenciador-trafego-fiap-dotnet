using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.Clima
{
    public interface IClimaRepository
    {
        IEnumerable<ClimaModel> GetAll();
        ClimaModel GetById(int id);
        ClimaModel Add(ClimaModel model);
        ClimaModel Update(ClimaModel model);
        void DeleteById(ClimaModel model);
    }
}
