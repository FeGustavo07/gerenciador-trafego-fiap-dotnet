using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository;
using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.ViewModel;

namespace fiap.gerenciador_trafego.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public void Add(UsuarioCreateViewModel usuarioCreateViewModel)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioCreateViewModel);
            _usuarioRepository.Add(usuario);
        }

        public UsuarioGetViewModel GetByNomeESenha(UsuarioLoginViewModel usuarioLoginViewModel)
        {
            var usuarioModel = _usuarioRepository.GetByNomeESenha(usuarioLoginViewModel.username, usuarioLoginViewModel.password);
            var usuarioViewModel = _mapper.Map<UsuarioGetViewModel>(usuarioModel);
            return usuarioViewModel;
        }
    }
}
