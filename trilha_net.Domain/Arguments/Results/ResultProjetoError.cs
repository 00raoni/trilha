using Newtonsoft.Json;
using trilha_net.Domain.Arguments.Enums;
using trilha_net.Domain.Exception;

namespace trilha_net.Domain.Arguments.Results
{
    /// <summary>
    /// Base do ResultErro
    /// </summary>
    public abstract class ResultProjetoErrorBase
    {
        /// <summary>
        /// Código da mensagem.
        /// </summary>
        [JsonProperty("code")]
        public int code { get; set; }
    }

    /// <summary>
    /// ResultErro padrão.
    /// </summary>
    public class ResultProjetoError : ResultProjetoErrorBase
    {
        public ResultProjetoError(ProjetoException exception)
        {
            this.code = (int)exception.HttpCode;
            this.message = exception.Message;
        }

        public ResultProjetoError(System.Exception exception)
        {
            this.code = (int)TipoHttpCode.HTTP_500_INTERNAL_SERVER_ERROR;
            this.message = exception.Message;
        }

        public ResultProjetoError(string mensagem, int codigoErro)
        {
            this.code = codigoErro;
            this.message = mensagem;
        }

        /// <summary>
        /// message de erro.
        /// </summary>
        [JsonProperty("message")]
        public string message { get; set; }
    }

    public class ResultProjetoErrors : ResultProjetoErrorBase
    {
        /// <summary>
        /// Lista mensagens de erro.
        /// </summary>
        [JsonProperty("messages")]
        public IEnumerable<string> messages { get; set; }
    }

    public class ResultProjetoErrorList
    {
        public ResultProjetoErrorList(IEnumerable<ProjetoException> erros) => 
            Erros = erros.Select(e => new ResultProjetoError(e));

        /// <summary>
        /// Lista erros.
        /// </summary>
        [JsonProperty("errors")]
        public IEnumerable<ResultProjetoError> Erros { get; set; }
    }
}
