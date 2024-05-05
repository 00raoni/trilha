using trilha_net.Infra.CrossCutting.Models;
using System.Linq.Expressions;

namespace trilha_net.Infra.CrossCutting.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        /// <summary>
        /// Insere um registro no banco
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Insere uma lista de registros no banco
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(TEntity entities);

        /// <summary>
        /// Consulta um registro pela sua Primary Key (PK)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity?> GetByIdAsync(Guid id);

        /// <summary>
        /// Consulta um registro no banco conforme a condição no predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Consulta uma lista de registros no banco conforme a condição no predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindUncommitted(Func<TEntity, bool> predicate);

        [Obsolete("Use o metodo GetByIdAsync(Guid id)")]
        Task<TEntity?> GetByIdAsync(params object[] id);

        Task<IEnumerable<TEntity>> FindAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>?> ReturnList(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>?> ReturnListTracking(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task CreateAsync(TEntity obj);
        void Create(TEntity obj);
        Task CreateRangeAsync(IEnumerable<TEntity> list);

        [Obsolete("Usar Update()")]
        Task UpdateAsync(TEntity obj);

        void Update(TEntity obj);
        Task UpdateRangeAsync(IEnumerable<TEntity> list);
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Exclui registros no banco conforme a condição no predicate
        /// </summary>
        /// <param name="predicate"></param>
        void DeleteAll(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
