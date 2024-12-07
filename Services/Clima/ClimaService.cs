using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.Clima;
using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel.Semaforo;

namespace fiap.gerenciador_trafego.Services.Clima;

public class ClimaService : IClimaService
{
    private readonly IClimaRepository _climaRepository;
    private readonly IMapper _mapper;
    
    public ClimaService(IClimaRepository repository, IMapper mapper)
    {
        _climaRepository = repository;
        _mapper = mapper;
    }

    public IEnumerable<ClimaGetViewlModel> GetAll()
    {
        var climas = _climaRepository.GetAll();
        return _mapper.Map<IEnumerable<ClimaGetViewlModel>>(climas);
    }

    public ClimaGetViewlModel GetById(long id)
    {
        var clima = _climaRepository.GetById(id);
        if (clima == null) throw new Exception("Clima não encontrado");
        return _mapper.Map<ClimaGetViewlModel>(clima);
    }

    public ClimaGetViewlModel Add(ClimaCreateViewModel climaCreateViewModel)
    {
        throw new NotImplementedException();
    }


    public ClimaGetViewlModel Create(ClimaCreateViewModel climaCreateViewModel)
    {
        var clima = _mapper.Map<ClimaModel>(climaCreateViewModel);
        clima = _climaRepository.Add(clima);
        return _mapper.Map<ClimaGetViewlModel>(clima);
    }
    
    public ClimaGetViewlModel Update(long id, ClimaUpdateViewModel climaUpdateViewModel)
    {
        var clima = _climaRepository.GetById(id);
        if (clima == null) throw new Exception("Clima não encontrado");
        _mapper.Map(climaUpdateViewModel, clima);
        clima = _climaRepository.Update(clima);
        return _mapper.Map<ClimaGetViewlModel>(clima);
    }

    public void DeleteById(long id)
    {
        var clima = _climaRepository.GetById(id);
        if (clima == null) throw new Exception("Clima não encontrado");
        _climaRepository.Delete(clima);
    }
}