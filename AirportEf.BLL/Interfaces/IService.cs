namespace AirportEf.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Airport.Common.Interfaces.Entities;
    using Airport.Common.Requests;

    public interface IService<TDto, TRequest, TKey> 
                        where TDto : IEntity<TKey>
                        //where TEntity : IEntity<TKey>
    {
        Task<IEnumerable<TDto>> GetAllEntitiesAsync();

        Task<IEnumerable<TDto>> GetAllEntitiesAsync(Filter filter);

        Task<TDto> GetEntityByIdAsync(TKey id);

        Task<TDto> CreateEntityAsync(TRequest request);

        Task<bool> UpdateEntityByIdAsync(TRequest request, TKey id); // TODO

        Task<bool> DeleteEntityByIdAsync(TKey id);
    }
}