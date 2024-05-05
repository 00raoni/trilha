using trilha_net.Domain.Arguments.Enums;

namespace trilha_net.Domain.Arguments.ViewModels
{
    public class RequestUsuario
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string? Senha { get; set; }        
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
    }
}
