using trilha_net.Domain.Arguments.Enums;
using trilha_net.Infra.CrossCutting.Extensions;
using trilha_net.Infra.CrossCutting.Interfaces;
using trilha_net.Infra.CrossCutting.Models;
using trilha_net.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace trilha_net.Infra.Data.Repositories
{

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ProjetoContext _context;
        protected DbSet<TEntity> DbSet;

        protected Repository(ProjetoContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> AddAsync(TEntity entity) => (await DbSet.AddAsync(entity)).Entity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(TEntity entities) => await DbSet.AddRangeAsync(entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetByIdAsync(Guid id) => await DbSet.FirstOrDefaultAsync(e => e.Id == id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.FirstOrDefaultAsync(predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Obsolete("Use o metodo GetByIdAsync(Guid id)")]
        public async Task<TEntity?> GetByIdAsync(params object[] id) => await DbSet.FindAsync(id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) => DbSet.Where(predicate);

        //TODO: Converter para metodo sincrono
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(DbSet.AsNoTracking().Where(predicate));
        }
        public async Task<List<TEntity>?> ReturnList(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Task.FromResult(DbSet.AsNoTracking().Where(predicate).ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<TEntity>?> ReturnListTracking(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Task.FromResult(DbSet.Where(predicate).ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }

        /* 
         * TODO: usar a extensão .ToList ou .ToListAsync ira forçar o EF a consultar no banco de dados,
         * dependento da logica, usar o IEnumerable no caso do entity e molhor, pois vc força a consulta no momento necessário
         */
        //TODO: Converter para metodo sincrono
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [Obsolete("Use o metodo GetAllAsync()")]
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(DbSet.Where(predicate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindUncommitted(Func<TEntity, bool> predicate) =>
            _context.ChangeTracker.Entries<TEntity>().Select(x => x.Entity).Where(predicate).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => DbSet.Where(predicate).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task CreateAsync(TEntity obj)
        {
            if (obj.Id.Equals(Guid.Empty))
            {
                obj.GenerateId();
            }

            await DbSet.AddAsync(obj);                        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Create(TEntity obj)
        {
            if (obj.Id.Equals(Guid.Empty))
            {
                obj.GenerateId();
            }

            DbSet.Add(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task CreateRangeAsync(IEnumerable<TEntity> list)
        {
            await _context.AddRangeAsync(list.Select(e =>
            {
                if (e.Id == Guid.Empty)
                    e.GenerateId();

                return e;
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Obsolete("Usar Update()")]
        public async Task UpdateAsync(TEntity obj)
        {
            await Task.Run(async () =>
            {
                obj.SetUpdatedAtUtc(DateTime.UtcNow);
                DbSet.Update(obj);               
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Update(TEntity obj)
        {
            obj.SetUpdatedAtUtc(DateTime.UtcNow);
            DbSet.Update(obj);
        }

        //TODO: tornar sincrono
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task UpdateRangeAsync(IEnumerable<TEntity> list)
        {
            await Task.Run(() =>
            {
                DbSet.UpdateRange(list.Select(e =>
                {
                    e.SetUpdatedAtUtc(DateTime.UtcNow);
                    return e;
                }).ToArray());
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(Guid id) =>
            DbSet.Remove(await DbSet.FindAsync(id) ?? throw new KeyNotFoundException(id.ToString()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        public void DeleteAll(Expression<Func<TEntity, bool>> predicate) =>
            DbSet.RemoveRange(DbSet.Where(predicate).AsEnumerable());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _context.SaveChangesAsync(cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
