using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.Rota;
using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel.Acidente;
using fiap.gerenciador_trafego.ViewModel.Rota;

namespace fiap.gerenciador_trafego.Services.Rota
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _rotaRepository;
        private readonly IMapper _mapper;

        public RotaService(IRotaRepository rotaRepository, IMapper mapper)
        {
            _rotaRepository = rotaRepository;
            _mapper = mapper;
        }

        public RotaGetViewModel Add(RotaCreateViewModel model)
        {
            var rota = _mapper.Map<RotaModel>(model);
            _rotaRepository.Add(rota);
            var rotaViewModel = _mapper.Map<RotaGetViewModel>(rota);
            return rotaViewModel;
        }

        public void DeleteById(int id)
        {
            var rota = _rotaRepository.GetById(id);
            _rotaRepository.DeleteById(rota);
        }

        public IEnumerable<RotaGetViewModel> GetAll()
        {
            var rotas = _rotaRepository.GetAll();
            var rotasModel = _mapper.Map<IEnumerable<RotaGetViewModel>>(rotas);
            return rotasModel;
        }

        public RotaGetViewModel GetById(int id)
        {
            var rota = _rotaRepository.GetById(id);
            var rotaViewModel = _mapper.Map<RotaGetViewModel>(rota);
            return rotaViewModel;
        }

        public RotaGetViewModel Update(int id, RotaUpdateViewModel model)
        {
            var rota = _rotaRepository.GetById(id);
            rota = _mapper.Map<RotaModel>(model);
            _rotaRepository.Add(rota);
            var rotaViewModel = _mapper.Map<RotaGetViewModel>(rota);
            return rotaViewModel;
        }
    }
}
