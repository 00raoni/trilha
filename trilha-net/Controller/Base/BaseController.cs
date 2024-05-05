using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using trilha_net.Domain.Arguments.Enums;
using trilha_net.Domain.Arguments.Results;
using trilha_net.Domain.Exception;
using trilha_net.Domain.Interfaces;
using trilha_net.Infra.CrossCutting.Interfaces;

namespace trilha_net.Controller.Base
{
    /// <summary>
    /// Controller Base Customizado, contem funções comuns dos endpoints usados na Api Projeto
    /// </summary>
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IProjetoDeErroService _notificacaoDeErro;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_notificacaoDeErro"></param>
        /// <param name="unitOfWork"></param>
        public BaseController(IProjetoDeErroService _notificacaoDeErro, IUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            this._notificacaoDeErro = _notificacaoDeErro;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        /// <summary>
        /// Trata os retornos e as exceções dos enpoints
        /// </summary>
        /// <typeparam name="TRetorno">Retorno do endpoint do tipo IActionResult</typeparam>
        /// <param name="endpoint">Metodo do endpoint</param>
        /// <returns></returns>
        protected async Task<IActionResult> Comum<TRetorno>(Func<Task<TRetorno>> endpoint) where TRetorno : IActionResult
        {
            try
            {
                TRetorno resposta = await endpoint();

                if (_notificacaoDeErro.HasErro)
                    return MontarResultError();

                await _unitOfWork.CommitAsync();
                return resposta;
            }
            catch (ProjetoException e)
            {
                return MontarJsonResultError(e);
            }
            catch (Exception e)
            {
                var resultError = new ResultProjetoError(e);
                return new JsonResult(resultError)
                {
                    StatusCode = (int)TipoHttpCode.HTTP_500_INTERNAL_SERVER_ERROR
                };
            }
        }

        private IActionResult MontarResultError()
        {
            if (_notificacaoDeErro.Exceptions.Count == 1)
                return MontarJsonResultError(_notificacaoDeErro.Exceptions.First());

            var resultError = new ResultProjetoErrorList(_notificacaoDeErro.Exceptions);
            return new JsonResult(resultError)
            {
                StatusCode = (int)_notificacaoDeErro.Exceptions.First().HttpCode
            };
        }

        private static JsonResult MontarJsonResultError(ProjetoException e)
        {
            var resultError = new ResultProjetoError(e);
            return new JsonResult(resultError)
            {
                StatusCode = (int)e.HttpCode
            };
        }
    }
}
