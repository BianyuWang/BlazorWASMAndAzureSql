using BlazorWASMAndAzureSql.Server.databases.DbContexts;
using BlazorWASMAndAzureSql.Server.IRepositories.IBaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Repositories.BaseRepositories
{


    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly SuperheroContext _SuperheroContext;
        public BaseRepository(SuperheroContext SuperheroContext)
        {
            _SuperheroContext = SuperheroContext;
        }
        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var savedEntity = (await _SuperheroContext.Set<TEntity>().AddAsync(entity, cancellationToken)).Entity;

         
                await _SuperheroContext.SaveChangesAsync(cancellationToken);
        
            return savedEntity;
        }
        protected SuperheroContext DbContext()
        {
            return _SuperheroContext;
        }


        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListAsync( CancellationToken cancellationToken = default)
        {
           
                return _SuperheroContext.Set<TEntity>().ToListAsync(cancellationToken);           


        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            int idDel=0;
            var dataSet = _SuperheroContext.Set<TEntity>();
            var entity = await dataSet.Where(predicate).FirstOrDefaultAsync(cancellationToken);
            if (entity != null)
            {
                _SuperheroContext.Set<TEntity>().Remove(entity);
                idDel= await _SuperheroContext.SaveChangesAsync(cancellationToken);
            }

            return idDel;

        }
    }
}
