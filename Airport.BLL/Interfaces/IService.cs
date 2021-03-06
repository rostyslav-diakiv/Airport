﻿namespace Airport.BLL.Interfaces
{
    using System.Collections.Generic;

    using Airport.Common.Interfaces.Entities;
    using Airport.Common.Requests;

    public interface IService<out TEntity, TDto, TRequest, TKey> 
                        where TDto : IEntity<TKey>
                        where TEntity : IEntity<TKey>
    {
        IEnumerable<TDto> GetAllEntity();

        IEnumerable<TDto> GetAllEntity(Filter filter);

        TDto GetEntityById(TKey id);

        TDto CreateEntity(TRequest request);

        TEntity UpdateEntityById(TRequest request, TKey id);

        bool DeleteEntityById(TKey id);
    }
}