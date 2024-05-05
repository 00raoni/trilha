using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using trilha_net.Controller.Base;
using trilha_net.Domain.Arguments.Enums;
using trilha_net.Domain.Arguments.Results;
using trilha_net.Domain.Arguments.ViewModels;
using trilha_net.Domain.Interfaces;
using trilha_net.Domain.Interfaces.Services;
using trilha_net.Domain.Models;
using trilha_net.Infra.CrossCutting.Interfaces;

namespace trilha_net.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioService"></param>
        /// <param name="projetoDeErroService"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public UsuarioController(
            IUsuarioService usuarioService,
            IProjetoDeErroService projetoDeErroService,
            IUnitOfWork unitOfWork, 
            IMapper mapper
        )
            : base(projetoDeErroService, unitOfWork, mapper)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Consultar usuario
        /// </summary>
        /// <param name="id">Identificador da usuario</param>
        /// <returns></returns>
        /// <remarks>
        /// Consulta Usuario por id
        /// 
        /// <pre>
        /// 
        /// </pre>
        /// 
        /// <code>
        /// Codigo
        /// </code>
        /// </remarks>
        /// <response code="200"> Ok </response>
        /// <response code="400"> Bad Request </response>
        /// <response code="401"> Unauthorized </response>
        /// <response code="403"> Forbidden </response>
        /// <response code="404"> Not Found</response>
        /// <response code="500"> Internal Server Error </response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseUsuario), 200)]
        [ProducesResponseType(typeof(ResultProjetoError), 500)]
        public async Task<IActionResult> GetById([FromRoute] Guid id) =>
            await Comum(async () =>
            {
                var usuario = await _usuarioService.ConsultarPorId<Usuario>(id);
                var result = _mapper.Map<ResponseUsuario>(usuario);
                return Ok(usuario);
            });

        /// <summary>
        /// Consultar lista de usuarios
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// Consulta Usuarios.
        /// 
        /// </remarks>
        /// <response code="200"> Ok </response>
        /// <response code="400"> Bad Request </response>
        /// <response code="401"> Unauthorized </response>
        /// <response code="403"> Forbidden </response>
        /// <response code="404"> Not Found</response>
        /// <response code="500"> Internal Server Error </response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseUsuario>), 200)]
        [ProducesResponseType(typeof(ResultProjetoError), 500)]
        public async Task<IActionResult> GetAll() =>
            await Comum(async () =>
            {
                var usuarios = await _usuarioService.ConsultarTodos<Usuario>(d => d.Status == TipoStatus.Ativo);
                var result = _mapper.Map<List<ResponseUsuario>>(usuarios);
                return Ok(usuarios);
            });

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// Cadastra Usuario
        /// 
        /// </remarks>
        /// <response code="200"> Ok </response>
        /// <response code="400"> Bad Request </response>
        /// <response code="401"> Unauthorized </response>
        /// <response code="403"> Forbidden </response>
        /// <response code="404"> Not Found</response>
        /// <response code="500"> Internal Server Error </response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ResultProjetoError), 500)]
        public async Task<IActionResult> Create(RequestUsuario request) =>
            await Comum(async () =>
            {                
                var usuarioId = await _usuarioService.CriarUsuario(request);
                return Ok(usuarioId);
            });

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador da usuario</param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// Alteração Usuario.
        /// 
        /// </remarks>
        /// <response code="200"> Ok </response>
        /// <response code="400"> Bad Request </response>
        /// <response code="401"> Unauthorized </response>
        /// <response code="403"> Forbidden </response>
        /// <response code="404"> Not Found</response>
        /// <response code="500"> Internal Server Error </response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ResultProjetoError), 500)]
        public async Task<IActionResult> Put(
            [FromRoute] Guid id,
            [FromBody] RequestUsuario request
        ) =>
            await Comum(async () =>
            {
                request.Id = id;                
                await _usuarioService.AtualizarUsuario(request);
                return NoContent();
            });

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador da usuario</param>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// Exclui Usuario.
        /// 
        /// </remarks>
        /// <response code="204"> No Content </response>
        /// <response code="400"> Bad Request </response>
        /// <response code="401"> Unauthorized </response>
        /// <response code="403"> Forbidden </response>
        /// <response code="404"> Not Found</response>
        /// <response code="500"> Internal Server Error </response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Usuario), 204)]
        [ProducesResponseType(typeof(ResultProjetoError), 500)]
        public async Task<IActionResult> Delete([FromRoute] Guid id) =>
            await Comum(async () =>
            {                
                await _usuarioService.Excluir(id);
                return NoContent();
            });
    }
}
