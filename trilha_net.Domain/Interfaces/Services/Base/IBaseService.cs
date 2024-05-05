using System.Linq.Expressions;

namespace trilha_net.Domain.Interfaces.Services.Base
{
    /// <summary>
    /// Serviço base dos serviços da API trilha_net
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Criar a o registro da entidade no banco de dados
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Guid> Criar<TRequest>(TRequest request);

        /// <summary>
        /// Consulta um registro no banco de dados pelo ID
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TResponse> ConsultarPorId<TResponse>(Guid id);

        /// <summary>
        /// Consulta uma lista de registro conforme os filtros passados.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TResponse>> ConsultarTodos<TResponse>(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Consulta uma lista de registro NoTracking conforme os filtros passados.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TResponse>?> ConsultarTodosNoTracking<TResponse>(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Consulta uma lista de registro conforme os filtros passados ou uma lista vazia
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TResponse>> ConsultarTodosOuNulo<TResponse>(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Atualizar o registro da entidade no banco de dados
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task Atualizar<TRequest>(TRequest request);

        /// <summary>
        /// Atualizar o registro da entidade no banco de dados
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Atualizar(TEntity entity);

        /// <summary>
        /// Excluir um registro no banco de dados
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task Excluir(Guid Id);
    }
}
