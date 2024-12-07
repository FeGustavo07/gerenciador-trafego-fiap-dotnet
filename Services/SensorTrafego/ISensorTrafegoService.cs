using fiap.gerenciador_trafego.ViewModel.Semaforo;
using fiap.gerenciador_trafego.ViewModel.SensorTrafego;

namespace fiap.gerenciador_trafego.Services.SensorTrafego
{
    public interface ISensorTrafegoService
    {
        IEnumerable<SensorTrafegoGetViewModel> GetAll();
        SensorTrafegoGetViewModel GetById(int id);
        SensorTrafegoGetViewModel Add(SensorTrafegoCreateViewModel model);
        SensorTrafegoGetViewModel Update(int id, SensorTrafegoUpdateViewlModel model);
        SensorTrafegoGetViewModel DeleteById(int id);
    }
}
