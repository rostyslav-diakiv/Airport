namespace AirportEf.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Airport.Common.Enums;
    using Airport.Common.Interfaces.Entities;
    using Airport.Common.Requests;
    
    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

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

        public abstract Task<IEnumerable<TDto>> GetAllEntitiesAsync();

        public virtual Task<IEnumerable<TDto>> GetAllEntitiesAsync(Filter filter)
        {
            return GetAllEntitiesAsync();
        }

        public abstract Task<TDto> GetEntityByIdAsync(TKey id);

        public abstract Task<TDto> CreateEntityAsync(TRequest request);

        public abstract Task<bool> UpdateEntityByIdAsync(TRequest request, TKey id);

        public abstract Task<bool> DeleteEntityByIdAsync(TKey id);

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
