namespace fiap.gerenciador_trafego.ViewModel
{
    public class UsuarioCreateViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }  // Em produção, nunca armazene senhas em texto claro.
        public string? Role { get; set; }
    }
}
