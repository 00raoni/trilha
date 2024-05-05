using System.Runtime.InteropServices;
using trilha_net.Domain.Arguments.Enums;
using trilha_net.Infra.CrossCutting.Extensions;

namespace trilha_net.Domain.Exception
{
    /// <summary>
    /// Exceções do trilha_net.
    /// </summary>
    public class ProjetoException : System.Exception
    {
        /// <summary>
        /// HttpCode da exceção.
        /// </summary>
        public TipoHttpCode HttpCode { get; private set; }
        
        /// <summary>
        /// Código trilha_net da exceção.
        /// O código são 6 digitos, sendo os 3 primeiros o HttpCode,
        /// e os 3 ultimos o código da mensagem retornada.
        /// </summary>
        public int CodigoErro { get; private set; }

        /// <summary>
        /// Cria uma exceção personalizada trilha_net.
        /// </summary>
        /// <param name="httpCode">HttpCode</param>
        /// <param name="innerException">Inner Exception</param>
        /// <param name="codigoErro">Código da mensagem.</param>
        public ProjetoException(TipoHttpCode httpCode, [Optional] System.Exception? innerException, [Optional] CodigoErro codigoErro)
            : base(httpCode.GetDescription(), innerException)
        {
            HttpCode = httpCode;
            CodigoErro = ((int)httpCode * 1000) + (int)codigoErro;
        }

        /// <summary>
        /// Cria uma exceção personalizada trilha_net.
        /// O Código terá o sulfixo do CodigoErro.GENERICO (999)
        /// </summary>
        /// <param name="httpCode">HttpCode</param>
        /// <param name="mensagem">Mensagem personalizada.</param>
        /// <param name="innerException">Inner Exception</param>
        public ProjetoException(TipoHttpCode httpCode, string mensagem, [Optional] System.Exception? innerException)
            : base(mensagem, innerException)
        {
            HttpCode = httpCode;
            CodigoErro = ((int)httpCode * 1000) + (int)Arguments.Enums.CodigoErro.GENERICO;
        }

        /// <summary>
        /// Cria uma exceção personalizada trilha_net.
        /// A mensagem retornada será a descrição do CodigoErro.
        /// </summary>
        /// <param name="httpCode">HttpCode</param>
        /// <param name="codigoErro">Código da mensagem.</param>
        /// <param name="innerException">Inner Exception</param>
        public ProjetoException(TipoHttpCode httpCode, CodigoErro codigoErro, [Optional] System.Exception? innerException)
            : base(codigoErro.GetDescription(), innerException)
        {
            HttpCode = httpCode;
            CodigoErro = ((int)httpCode * 1000) + (int)codigoErro;
        }

    }
}
