using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository;
using fiap.gerenciador_trafego.ViewModel;

namespace fiap.gerenciador_trafego.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUsuarioService _usuarioService;

        public AuthService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioGetViewModel Authenticate(UsuarioLoginViewModel usuarioLoginViewModel)
        {
            var usuario = _usuarioService.GetByNomeESenha(usuarioLoginViewModel);
            return usuario;
        }
    }
}
