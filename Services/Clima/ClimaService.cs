using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.Clima;
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
            throw new NotImplementedException();
        }

        public ClimaGetViewModel DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClimaGetViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClimaGetViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ClimaGetViewModel Update(int id, ClimaUpdateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
