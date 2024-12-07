using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel GetByNomeESenha(string nome, string senha);
        void Add(UsuarioModel usuario);
    }
}
