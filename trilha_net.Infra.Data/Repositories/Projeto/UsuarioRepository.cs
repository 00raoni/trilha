using trilha_net.Domain.Interfaces.Repositories;
using trilha_net.Domain.Models;
using trilha_net.Infra.Data.Context;

namespace trilha_net.Infra.Data.Repositories.Projeto
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        protected ProjetoContext _context;
        public UsuarioRepository(ProjetoContext context) : base(context)
        {
            _context = context;
        }
    }
}