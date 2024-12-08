using fiap.gerenciador_trafego.Models;

namespace fiap.gerenciador_trafego.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _context;

        public UsuarioRepository(DatabaseContext context)
        {
            _context = context;
        }
        
        public void Add(UsuarioModel usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public UsuarioModel GetByNomeESenha(string nome, string senha)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Username == nome && u.Password == senha);
            return usuario;
        }
    }
}
