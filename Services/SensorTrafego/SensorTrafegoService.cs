using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.SensorTrafego;
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
            throw new NotImplementedException();
        }

        public SensorTrafegoGetViewModel DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SensorTrafegoGetViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SensorTrafegoGetViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public SensorTrafegoGetViewModel Update(int id, SensorTrafegoUpdateViewlModel model)
        {
            throw new NotImplementedException();
        }
    }
}
