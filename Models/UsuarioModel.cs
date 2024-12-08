using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fiap.gerenciador_trafego.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // Em produção, nunca armazene senhas em texto claro.
        public string? Role { get; set; }
    }
}
