namespace ClientLight.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IService<TDto, TKey>
    {
        Task<IEnumerable<TDto>> GetAllEntities();

        Task<TDto> CreateEntitiesAsync(TDto dto);

        Task<bool> UpdateEntitiesByIdAsync(TDto dto);

        Task<bool> DeleteEntitiesByIdAsync(TKey id);
    }
}