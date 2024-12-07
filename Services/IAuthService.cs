using fiap.gerenciador_trafego.ViewModel;

namespace fiap.gerenciador_trafego.Services
{
    public interface IAuthService
    {
        UsuarioGetViewModel Authenticate(UsuarioLoginViewModel usuarioLoginViewModel);
    }
}
