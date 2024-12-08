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

        public void DeleteById(long id)
        {
            var clima = _climaRepository.GetById(id);
            _climaRepository.Delete(clima);
        }

        public IEnumerable<ClimaGetViewModel> GetAll()
        {
            var climas = _climaRepository.GetAll();
            var climasModel = _mapper.Map<IEnumerable<ClimaGetViewModel>>(climas);
            return climasModel;
        }

        public ClimaGetViewModel GetById(long id)
        {
            var clima = _climaRepository.GetById(id);
            var climaModel = _mapper.Map<ClimaGetViewModel>(clima);
            return climaModel;
        }

        public ClimaGetViewModel Update(long id, ClimaUpdateViewModel model)
        {
            var clima = _climaRepository.GetById(id);
            if (clima == null) throw new Exception("Clima não encontrado");
            _mapper.Map(model, clima);
            clima = _climaRepository.Update(clima);
            return _mapper.Map<ClimaGetViewModel>(clima);
        }
    }
}
