using trilha_net.Domain.Arguments.Enums;
using trilha_net.Domain.Exception;
using System.Runtime.InteropServices;

namespace trilha_net.Domain.Interfaces
{
    /// <summary>
    /// Gerenciador de Exceções/Erros
    /// </summary>
    public interface IProjetoDeErroService
    {
        /// <summary>
        /// Retorna TRUE se existir ao menos uma exceção na sessão.
        /// </summary>
        bool HasErro { get; }

        /// <summary>
        /// Consulta a lista de exceções da sessão.
        /// </summary>
        List<ProjetoException> Exceptions { get; }

        /// <summary>
        /// Adiciona uma exceção á sessão.
        /// </summary>
        /// <param name="tipoErro">HttpCode que será retonado pelo Endpoint.</param>
        /// <param name="mensagem">Mensagem de erro personalizada.</param>
        /// <param name="innerException">Inner Exception</param>
        /// <returns></returns>
        Task Add(TipoHttpCode tipoErro, [Optional] string? mensagem, [Optional] System.Exception? innerException);

        /// <summary>
        /// Adiciona uma exceção á sessão.
        /// </summary>
        /// <param name="tipoErro">HttpCode que será retonado pelo Endpoint.</param>
        /// <param name="code">Código de erro da mensagem.</param>
        /// <param name="innerException">Inner Exception</param>
        /// <returns></returns>
        Task Add(TipoHttpCode tipoErro, CodigoErro code, [Optional] System.Exception? innerException);

        /// <summary>
        /// Adiciona uma exceção á sessão.
        /// </summary>
        /// <param name="projetoException">Objeto de exceção personalizado do trilha_net.</param>
        /// <returns></returns>
        Task Add(ProjetoException projetoException);

        /// <summary>
        /// Adiciona uma ou mais exceções á sessão.
        /// Cada mensagem personalizada adicionará uma exceção á sessão, todas serão do TipoErro informado.
        /// </summary>
        /// <param name="tipoErro">HttpCode que será retonado pelo Endpoint.</param>
        /// <param name="mensagem">Lista de mensagem de erro personalizada.</param>
        /// <returns></returns>
        Task AddRange(TipoHttpCode tipoErro, IEnumerable<string> mensagem);

        /// <summary>
        /// Adiciona uma ou mais exceções á sessão.
        /// </summary>
        /// <param name="projetoException">Lista de objeto de exceção personalizado do trilha_net.</param>
        /// <returns></returns>
        Task AddRange(IEnumerable<ProjetoException> projetoException);
    }
}
