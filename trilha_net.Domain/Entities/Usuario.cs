using trilha_net.Domain.Arguments.Enums;
using trilha_net.Infra.CrossCutting.Models;

namespace trilha_net.Domain.Models
{
    public class Usuario : Entity
    {                
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public TipoStatus? Status { get; set; }
    }
}
