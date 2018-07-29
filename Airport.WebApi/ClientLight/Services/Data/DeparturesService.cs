namespace ClientLight.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;

    public class DeparturesService : BaseService<DepartureDto, DepartureRequest, int>, IDeparturesService
    {
        public const string Ctrl_Name = "Departures";

        public Task<IEnumerable<DepartureDto>> GetAllEntitiesAsync()
        {
            return base.GetAllEntities(Ctrl_Name);
        }

        public Task<DepartureDto> CreateEntityAsync(DepartureDto dto)
        {
            var request = new DepartureRequest(dto);

            return base.CreateEntitiesAsync(request, Ctrl_Name);
        }

        public Task<bool> UpdateEntityByIdAsync(DepartureDto dto)
        {
            var request = new DepartureRequest(dto);

            return base.UpdateEntitiesByIdAsync(request, dto.Id, Ctrl_Name);
        }

        public Task<bool> DeleteEntityByIdAsync(int id)
        {
            return base.DeleteEntitiesByIdAsync(id, Ctrl_Name);
        }
    }
}
