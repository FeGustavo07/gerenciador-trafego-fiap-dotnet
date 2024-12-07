using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.Acidente
{
    public interface IAcidenteRepository
    {
        IEnumerable<AcidenteModel> GetAll();
        AcidenteModel GetById(int id);
        AcidenteModel Add(AcidenteModel model);
        AcidenteModel Update(AcidenteModel model);
        void DeleteById(AcidenteModel model);
    }
}
