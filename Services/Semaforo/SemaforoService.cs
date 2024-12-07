using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.Semaforo;
using fiap.gerenciador_trafego.ViewModel.Semaforo;

namespace fiap.gerenciador_trafego.Services.Semaforo
{
    public class SemaforoService : ISemaforoService
    {

        private readonly ISemaforoRepository _semaforoReposiroty;
        private readonly IMapper _mapper;

        public SemaforoService(
            ISemaforoRepository semaforoRepository,
            IMapper mapper
            ) 
        {
            _semaforoReposiroty = semaforoRepository;
            _mapper = mapper;
        }

        public SemaforoGetViewlModel Add(SemaforoCreateViewModel model)
        {
           

            throw new NotImplementedException();
        }

        public SemaforoGetViewlModel DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SemaforoGetViewlModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SemaforoGetViewlModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public SemaforoGetViewlModel Update(int id, SemaforoUpdateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
