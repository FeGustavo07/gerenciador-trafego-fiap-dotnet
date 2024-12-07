using fiap.gerenciador_trafego.ViewModel;

namespace fiap.gerenciador_trafego.Services
{
    public interface IUsuarioService
    {
        UsuarioGetViewModel GetByNomeESenha(UsuarioLoginViewModel usuarioLoginViewModel);
        void Add(UsuarioCreateViewModel usuarioCreateViewModel);
    }
}
