using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository.SensorTrafego
{
    public interface ISensorTrafegoRepository
    {
        IEnumerable<SensorTrafegoModel> GetAll();
        SensorTrafegoModel GetById(int id);
        SensorTrafegoModel Add(SensorTrafegoModel model);
        SensorTrafegoModel Update(SensorTrafegoModel model);
        void DeleteById(SensorTrafegoModel model);
    }
}
