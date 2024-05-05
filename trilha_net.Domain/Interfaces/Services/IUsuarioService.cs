using trilha_net.Domain.Arguments.ViewModels;
using trilha_net.Domain.Interfaces.Services.Base;
using trilha_net.Domain.Models;

namespace trilha_net.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task AtualizarUsuario(RequestUsuario request);
        Task<Guid> CriarUsuario(RequestUsuario request);
    }
}
