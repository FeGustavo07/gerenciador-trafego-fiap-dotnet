using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.Semaforo;
using fiap.gerenciador_trafego.Models;
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
            var semaforo = _mapper.Map<SemaforoModel>(model);
            _semaforoReposiroty.Add(semaforo);
            var semaforoViewModel = _mapper.Map<SemaforoGetViewlModel>(semaforo);
            return semaforoViewModel;
        }

        public void DeleteById(int id)
        {
            var semaforo = _semaforoReposiroty.GetById(id);
            _semaforoReposiroty.DeleteById(semaforo);
        }

        public IEnumerable<SemaforoGetViewlModel> GetAll()
        {
            var semaforos = _semaforoReposiroty.GetAll();
            var semaforosModel = _mapper.Map<IEnumerable<SemaforoGetViewlModel>>(semaforos);
            return semaforosModel;
        }

        public SemaforoGetViewlModel GetById(int id)
        {
            var semaforo = _semaforoReposiroty.GetById(id);
            var semaforoModel = _mapper.Map<SemaforoGetViewlModel>(semaforo);
            return semaforoModel;
        }

        public SemaforoGetViewlModel Update(int id, SemaforoUpdateViewModel model)
        {
            var semaforo = _semaforoReposiroty.GetById(id);
            semaforo = _mapper.Map<SemaforoModel>(model);
            _semaforoReposiroty.Add(semaforo);
            var semaforoViewModel = _mapper.Map<SemaforoGetViewlModel>(semaforo);
            return semaforoViewModel;
        }
    }
}
