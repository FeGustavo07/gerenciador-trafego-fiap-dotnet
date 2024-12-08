namespace fiap.gerenciador_trafego.ViewModel
{
    public class UsuarioLoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }  // Em produção, nunca armazene senhas em texto claro.
    }
}
