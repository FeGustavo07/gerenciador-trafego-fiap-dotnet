using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.Clima;
using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel.Clima;

namespace fiap.gerenciador_trafego.Services.Clima
{
    public class ClimaService : IClimaService
    {

        private readonly IClimaRepository _climaRepository;
        private readonly IMapper _mapper;

        public ClimaService(IClimaRepository climaRepository, IMapper mapper)
        {
            _climaRepository = climaRepository;
            _mapper = mapper;
        }   

        public ClimaGetViewModel Add(ClimaCreateViewModel model)
        {
            var clima = _mapper.Map<ClimaModel>(model);
            _climaRepository.Add(clima);
            var climaViewModel = _mapper.Map<ClimaGetViewModel>(clima);
            return climaViewModel;
        }

        public void DeleteById(int id)
        {
            var clima = _climaRepository.GetById(id);
            _climaRepository.DeleteById(clima);
        }

        public IEnumerable<ClimaGetViewModel> GetAll()
        {
            var climas = _climaRepository.GetAll();
            var climasModel = _mapper.Map<IEnumerable<ClimaGetViewModel>>(climas);
            return climasModel;
        }

        public ClimaGetViewModel GetById(int id)
        {
            var clima = _climaRepository.GetById(id);
            var climaModel = _mapper.Map<ClimaGetViewModel>(clima);
            return climaModel;
        }

        public ClimaGetViewModel Update(int id, ClimaUpdateViewModel model)
        {
            var clima = _climaRepository.GetById(id);
            clima = _mapper.Map<ClimaModel>(model);
            _climaRepository.Add(clima);
            var climaViewModel = _mapper.Map<ClimaGetViewModel>(clima);
            return climaViewModel;
        }
    }
}
