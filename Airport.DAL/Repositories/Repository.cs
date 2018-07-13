namespace Airport.DAL.Repositories
{
    using System;
    using System.Collections.Generic;

    using System.Linq;

    using Airport.Common.Interfaces.Entities;
    using Airport.DAL.Interfaces.Repositories;

    using AutoMapper;

    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, IIdGeneratable<TKey>
    {
        protected readonly List<TEntity> _entities;
        protected readonly IMapper _mapper;

        protected Repository(List<TEntity> entities, IMapper mapper)
        {
            _entities = entities;
            _mapper = mapper;
        }

        public virtual TEntity Create(TEntity entity)
        {
            entity.Id = entity.GetGeneratedId();
            _entities.Add(entity);
            return entity;
        }

        public virtual ICollection<TEntity> CreateMany(ICollection<TEntity> items)
        {
            foreach (var i in items)
            {
                i.Id = i.GetGeneratedId();
            }

            _entities.AddRange(items);
            return items;
        }

        public virtual List<TEntity> GetRange(int index = 1,
                                      int count = 3,
                                      Func<TEntity, bool> filter = null,
                                      Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null)
        {
            IEnumerable<TEntity> resEntities = _entities;

            if (filter != null)
            {
                resEntities = resEntities.Where(filter);
            }

            if (orderBy == null)
            {
                resEntities = resEntities.OrderBy(a => a.Id);
            }
            else
            {
                resEntities = orderBy(resEntities);
            }

            if (index == 0) index = 1;
            if (count == 0) count = 3;

            return resEntities.Skip((index - 1) * count).Take(count).ToList();
        }


        public virtual TEntity GetFirstOrDefault(Func<TEntity, bool> filter = null,
                                         Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null)
        {
            IEnumerable<TEntity> resEntities = _entities;

            if (filter != null)
            {
                resEntities = resEntities.Where(filter);
            }

            if (orderBy == null)
            {
                resEntities = resEntities.OrderBy(a => a.Id);
            }
            else
            {
                resEntities = orderBy(resEntities);
            }

            return resEntities.FirstOrDefault();
        }

        public virtual TEntity Update(TEntity entity)
        {
            var findEntity = GetFirstOrDefault(e => e.Id.Equals(entity.Id));
            if (findEntity == null)
            {
                return null;
            }

            return _mapper.Map(entity, findEntity);
        }

        public virtual bool Delete(TKey id)
        {
            var entityToDelete = _entities.SingleOrDefault(e => e.Id.Equals(id));
            if (entityToDelete == null)
            {
                return false;
            }

            return Delete(entityToDelete);
        }

        public virtual bool Delete(TEntity entityToDelete)
        {
            return _entities.Remove(entityToDelete);
        }

        public virtual IEnumerable<bool> DeleteMany(Func<TEntity, bool> predicate = null)
        {
            var entitiesToDelete = GetRange(count: int.MaxValue, filter: predicate); // TODO:Add skip = 1, Take 1000000

            foreach (var e in entitiesToDelete)
            {
                yield return _entities.Remove(e);
            }
        }

        public virtual bool Exist(Func<TEntity, bool> predicate)
        {
            return _entities.Any(predicate);
        }

        public virtual int Count(Func<TEntity, bool> predicate)
        {
            return _entities.Count(predicate);
        }
    }
}
