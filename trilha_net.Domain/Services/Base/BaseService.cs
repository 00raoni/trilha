using AutoMapper;
using trilha_net.Domain.Arguments.Enums;
using trilha_net.Domain.Exception;
using trilha_net.Domain.Interfaces.Services.Base;
using trilha_net.Infra.CrossCutting.Interfaces;
using trilha_net.Infra.CrossCutting.Models;
using System.Linq.Expressions;

namespace trilha_net.Domain.Services.Base
{
    /// <summary>
    /// Serviço base dos serviços da API trilha_net
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseService<TRepository, TEntity> : IBaseService<TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// repositorio
        /// </summary>
        protected readonly TRepository _repository;
        /// <summary>
        /// mapper
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Extensão do Construtor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public BaseService(TRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Criar a o registro da entidade no banco de dados
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Guid> Criar<TRequest>(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            await _repository.CreateAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// Consulta um registro no banco de dados pelo ID
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TResponse> ConsultarPorId<TResponse>(Guid id)
        {
            TEntity? entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                throw new ProjetoException(TipoHttpCode.HTTP_404_NOT_FOUND);

            return _mapper.Map<TResponse>(entity);
        }

        /// <summary>
        /// Consulta uma lista de registro conforme os filtros passados.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ProjetoException">404 Not Found</exception>
        public async Task<List<TResponse>> ConsultarTodos<TResponse>(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = _repository.GetAll(predicate);            
            if (entities is null || !entities.Any())
                throw new ProjetoException(TipoHttpCode.HTTP_404_NOT_FOUND);

            return await Task.FromResult(_mapper.Map<List<TResponse>>(entities.ToList()));
        }
        /// <summary>
        /// Consulta uma lista de registro NoTracking conforme os filtros passados
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ProjetoException">404 Not Found</exception>
        public async Task<List<TResponse>?> ConsultarTodosNoTracking<TResponse>(Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> entities = await _repository.ReturnList(predicate);
            if (entities is null || !entities.Any())
                return null;

            return await Task.FromResult(_mapper.Map<List<TResponse>>(entities.ToList()));
        }
        /// <summary>
        /// Consulta uma lista de registro conforme os filtros passados ou uma lista vazia.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ProjetoException">404 Not Found</exception>
        public async Task<List<TResponse>> ConsultarTodosOuNulo<TResponse>(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = _repository.GetAll(predicate);
            if (entities is null || !entities.Any())
                return new List<TResponse>();
            return await Task.FromResult(_mapper.Map<List<TResponse>>(entities.ToList()));
        }

        /// <summary>
        /// Atualizar o registro da entidade no banco de dados
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task Atualizar<TRequest>(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            _repository.Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Atualizar o registro da entidade no banco de dados
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Atualizar(TEntity entity)
        {
            _repository.Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Excluir um registro no banco de dados
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task Excluir(Guid Id) => await _repository.DeleteAsync(Id);
    }
}
