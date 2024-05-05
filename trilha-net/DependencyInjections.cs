using trilha_net.Domain.Exception;
using trilha_net.Domain.Interfaces;
using trilha_net.Domain.Interfaces.Repositories;
using trilha_net.Domain.Interfaces.Services;
using trilha_net.Domain.Services;
using trilha_net.Infra.CrossCutting.Interfaces;
using trilha_net.Infra.Data.Repositories.Projeto;
using trilha_net.Infra.Data.Uow;

namespace trilha_net
{
    /// <summary>
    /// Configuração de injeção de dependencias
    /// </summary>
    public static class DependencyInjections
    {
        /// <summary>
        /// Adiciona injeções de dependencias dos serviços
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IUsuarioService, UsuarioService>()
            .AddScoped<IProjetoDeErroService, ProjetoDeErroService>()
            
                    ;

        /// <summary>
        /// Adiciona injeções de dependencias dos repositorios
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<IUsuarioRepository, UsuarioRepository>()            
            ;

    }
}
