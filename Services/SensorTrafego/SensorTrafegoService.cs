using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.SensorTrafego;
using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel.Acidente;
using fiap.gerenciador_trafego.ViewModel.SensorTrafego;

namespace fiap.gerenciador_trafego.Services.SensorTrafego
{
    public class SensorTrafegoService : ISensorTrafegoService
    {

        private readonly ISensorTrafegoRepository _sensorTrafegoRepository;
        private readonly IMapper _mapper;

        public SensorTrafegoService(ISensorTrafegoRepository sensorTrafegoRepository, IMapper mapper)
        {
            _sensorTrafegoRepository = sensorTrafegoRepository;
            _mapper = mapper;
        }

        public SensorTrafegoGetViewModel Add(SensorTrafegoCreateViewModel model)
        {
            var sensor = _mapper.Map<SensorTrafegoModel>(model);
            _sensorTrafegoRepository.Add(sensor);
            var sensorTrafegoViewModel = _mapper.Map<SensorTrafegoGetViewModel>(sensor);
            return sensorTrafegoViewModel;
        }

        public void DeleteById(int id)
        {
            var sensor = _sensorTrafegoRepository.GetById(id);
            _sensorTrafegoRepository.DeleteById(sensor);
        }

        public IEnumerable<SensorTrafegoGetViewModel> GetAll()
        {
            var sensores = _sensorTrafegoRepository.GetAll();
            var sensorModel = _mapper.Map<IEnumerable<SensorTrafegoGetViewModel>>(sensores);
            return sensorModel;
        }

        public SensorTrafegoGetViewModel GetById(int id)
        {
            var sensor = _sensorTrafegoRepository.GetById(id);
            var sensorModel = _mapper.Map<SensorTrafegoGetViewModel>(sensor);
            return sensorModel;
        }

        public SensorTrafegoGetViewModel Update(int id, SensorTrafegoUpdateViewlModel model)
        {
            var sensor = _sensorTrafegoRepository.GetById(id);
            sensor = _mapper.Map<SensorTrafegoModel>(model);
            _sensorTrafegoRepository.Add(sensor);
            var sensorViewModel = _mapper.Map<SensorTrafegoGetViewModel>(sensor);
            return sensorViewModel;
        }
    }
}
