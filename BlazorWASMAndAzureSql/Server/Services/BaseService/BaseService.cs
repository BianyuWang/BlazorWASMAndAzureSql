using BlazorWASMAndAzureSql.Server.IRepositories.IBaseRepositories;
using BlazorWASMAndAzureSql.Server.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Services.BaseService
{
    public class BaseServices<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {


        public IBaseRepository<TEntity> _baseRepository;

        public BaseServices(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _baseRepository.DeleteAsync(predicate, cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return await _baseRepository.GetListAsync(cancellationToken);
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await _baseRepository.InsertAsync(entity, cancellationToken);
        }
    }
}
