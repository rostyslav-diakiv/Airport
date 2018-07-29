namespace ClientLight.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;

    public class PlaneTypesService : IPlaneTypesService
    {
        public Task<IEnumerable<PlaneTypeDto>> GetAllEntities()
        {
            throw new System.NotImplementedException();
        }

        public Task<PlaneTypeDto> CreateEntitiesAsync(PlaneTypeDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateEntitiesByIdAsync(PlaneTypeDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteEntitiesByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
