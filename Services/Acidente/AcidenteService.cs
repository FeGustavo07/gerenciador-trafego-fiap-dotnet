using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.Acidente;
using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel.Acidente;

namespace fiap.gerenciador_trafego.Services.Acidente
{
    public class AcidenteService : IAcidenteService
    {
        private readonly IAcidenteRepository _acidenteRepository;
        private readonly IMapper _mapper;

        public AcidenteService(IAcidenteRepository acidenteRepository, IMapper mapper)
        {
            _acidenteRepository = acidenteRepository;
            _mapper = mapper;
        }

        public AcidenteGetViewModel Add(AcidenteCreateViewModel model)
        {
            var acidente = _mapper.Map<AcidenteModel>(model);
            _acidenteRepository.Add(acidente);
            var acidenteViewModel = _mapper.Map<AcidenteGetViewModel>(acidente);
            return acidenteViewModel;
            
        }

        public void DeleteById(int id)
        {
            var acidente = _acidenteRepository.GetById(id);
            _acidenteRepository.DeleteById(acidente);
           
        }

        public IEnumerable<AcidenteGetViewModel> GetAll()
        {
            var acidentes = _acidenteRepository.GetAll();
            var acidentesModel = _mapper.Map<IEnumerable<AcidenteGetViewModel>>(acidentes);
            return acidentesModel;
        }

        public AcidenteGetViewModel GetById(int id)
        {
            var acidente = _acidenteRepository.GetById(id);
            var acidenteModel = _mapper.Map<AcidenteGetViewModel>(acidente);
            return acidenteModel;
        }

        public AcidenteGetViewModel Update(int id, AcidenteUpdateViewModel model)
        {
            var acidente = _acidenteRepository.GetById(id);
            acidente = _mapper.Map<AcidenteModel>(model);
            _acidenteRepository.Add(acidente);
            var acidenteViewModel = _mapper.Map<AcidenteGetViewModel>(acidente);
            return acidenteViewModel;
        }
    }
}
