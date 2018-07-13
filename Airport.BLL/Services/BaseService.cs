namespace Airport.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Airport.BLL.Interfaces;
    using Airport.Common.Enums;
    using Airport.Common.Interfaces.Entities;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public abstract class BaseService<TEntity, TDto, TRequest, TKey> : IService<TDto, TRequest, TKey> where TDto : IEntity<TKey> 
                                                                                                      where TEntity : Entity<TKey>
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;

        protected BaseService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public abstract IEnumerable<TDto> GetAllEntity();

        public virtual IEnumerable<TDto> GetAllEntity(Filter filter)
        {
            return GetAllEntity();
        }

        public abstract TDto GetEntityById(TKey id);

        public abstract TDto CreateEntity(TRequest request);

        public abstract TDto UpdateEntityById(TRequest request, TKey id);

        public abstract bool DeleteEntityById(TKey id);

        protected TDto MapEntity(TEntity entity)
        {
            if (entity == null)
            {
                return default(TDto);
            }

            var dto = mapper.Map<TEntity, TDto>(entity);

            return dto;
        }

        protected Func<TEntity, bool> CreateFilterExpression(string searchString)
        {
            Func<TEntity, bool> filterExpression = pr => true;
            if (string.IsNullOrWhiteSpace(searchString))
                return filterExpression;
            

            // TODO

            return filterExpression;
        }

        protected Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> CreateOrderExpression(OrderBy filter)
        {
            Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderByFunc = oe => null;
                
            // TODO

            return orderByFunc;
        }
    }
}
