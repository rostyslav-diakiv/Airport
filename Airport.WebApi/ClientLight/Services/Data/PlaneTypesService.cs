namespace ClientLight.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;

    public class PlaneTypesService : BaseService<PlaneTypeDto, PlaneTypeRequest, int>, IPlaneTypesService
    {
        public const string Ctrl_Name = "PlaneTypes";

        public Task<IEnumerable<PlaneTypeDto>> GetAllEntitiesAsync()
        {
            return base.GetAllEntities(Ctrl_Name);
        }

        public Task<PlaneTypeDto> CreateEntityAsync(PlaneTypeDto dto)
        {
            var request = new PlaneTypeRequest(dto);

            return base.CreateEntitiesAsync(request, Ctrl_Name);
        }

        public Task<bool> UpdateEntityByIdAsync(PlaneTypeDto dto)
        {
            var request = new PlaneTypeRequest(dto);

            return base.UpdateEntitiesByIdAsync(request, dto.Id, Ctrl_Name);
        }

        public Task<bool> DeleteEntityByIdAsync(int id)
        {
            return base.DeleteEntitiesByIdAsync(id, Ctrl_Name);
        }
    }
}
