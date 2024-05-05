using System.Runtime.InteropServices;
using trilha_net.Domain.Arguments.Enums;
using trilha_net.Domain.Interfaces;

namespace trilha_net.Domain.Exception
{
    /// <summary>
    /// 
    /// </summary>
    public class ProjetoDeErroService: IProjetoDeErroService
    {
        private List<ProjetoException> _exceptions;

        /// <summary>
        /// 
        /// </summary>
        public ProjetoDeErroService() => _exceptions = new();

        /// <summary>
        /// 
        /// </summary>
        public bool HasErro => _exceptions.Any();

        /// <summary>
        /// 
        /// </summary>
        public List<ProjetoException> Exceptions => _exceptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoErro"></param>
        /// <param name="mensagem"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public Task Add(TipoHttpCode tipoErro, [Optional] string? mensagem, [Optional] System.Exception? innerException)
        {
            if(mensagem is null)
                _exceptions.Add(new ProjetoException(tipoErro, innerException));
            else
                _exceptions.Add(new ProjetoException(tipoErro, mensagem, innerException));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoErro"></param>
        /// <param name="code"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public Task Add(TipoHttpCode tipoErro, CodigoErro code, [Optional] System.Exception? innerException)
        {
            _exceptions.Add(new ProjetoException(tipoErro, code, innerException));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projetoException"></param>
        /// <returns></returns>
        public Task Add(ProjetoException projetoException)
        {
            _exceptions.Add(projetoException); 
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoErro"></param>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        public Task AddRange(TipoHttpCode tipoErro, IEnumerable<string> mensagem)
        {
            var exceptions = mensagem.Select(e => new ProjetoException(tipoErro, e));
            _exceptions.AddRange(exceptions);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projetoException"></param>
        /// <returns></returns>
        public Task AddRange(IEnumerable<ProjetoException> projetoException)
        {
            _exceptions.AddRange(projetoException);
            return Task.CompletedTask;
        }
    }
}
