namespace ClientLight.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IService<TDto, TKey>
    {
        Task<IEnumerable<TDto>> GetAllEntitiesAsync();

        Task<TDto> CreateEntityAsync(TDto dto);

        Task<bool> UpdateEntityByIdAsync(TDto dto);

        Task<bool> DeleteEntityByIdAsync(TKey id);
    }
}