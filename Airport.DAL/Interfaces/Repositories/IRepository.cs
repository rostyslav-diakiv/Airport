using System;
using System.Collections.Generic;

namespace Airport.DAL.Interfaces.Repositories
{
    using System.Linq;

    using Airport.Common.Interfaces.Entities;

    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Create(TEntity entity);
        ICollection<TEntity> CreateMany(ICollection<TEntity> items);
        bool Delete(TEntity entityToDelete);
        bool Delete(TKey id);

        IEnumerable<bool> DeleteMany(Func<TEntity, bool> predicate = null);
        TEntity Update(TEntity entity);
        int Count(Func<TEntity, bool> filter);
        bool Exist(Func<TEntity, bool> filter);
        TEntity GetFirstOrDefault(Func<TEntity, bool> filter = null,
                                  Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null);

        List<TEntity> GetRange(int index = 1,
                               int count = 10,
                               Func<TEntity, bool> filter = null,
                               Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null);
    }
}
