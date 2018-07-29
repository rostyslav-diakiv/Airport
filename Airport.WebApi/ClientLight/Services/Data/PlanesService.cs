namespace ClientLight.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;
    public class PlanesService : BaseService<PlaneDto, PlaneRequest, int>, IPlanesService
    {
        public const string Ctrl_Name = "Planes";

        public Task<IEnumerable<PlaneDto>> GetAllEntitiesAsync()
        {
            return base.GetAllEntities(Ctrl_Name);
        }

        public Task<PlaneDto> CreateEntityAsync(PlaneDto dto)
        {
            var request = new PlaneRequest(dto);

            return base.CreateEntitiesAsync(request, Ctrl_Name);
        }

        public Task<bool> UpdateEntityByIdAsync(PlaneDto dto)
        {
            var request = new PlaneRequest(dto);

            return base.UpdateEntitiesByIdAsync(request, dto.Id, Ctrl_Name);
        }

        public Task<bool> DeleteEntityByIdAsync(int id)
        {
            return base.DeleteEntitiesByIdAsync(id, Ctrl_Name);
        }
    }
}
