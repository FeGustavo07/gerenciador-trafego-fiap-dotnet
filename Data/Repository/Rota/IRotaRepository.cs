using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.Rota
{
    public interface IRotaRepository
    {
        IEnumerable<RotaModel> GetAll();
        RotaModel GetById(int id);
        RotaModel Add(RotaModel model);
        RotaModel Update(RotaModel model);
        void DeleteById(RotaModel model);
    }
}
