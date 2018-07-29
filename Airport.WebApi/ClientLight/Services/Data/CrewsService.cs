namespace ClientLight.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;
    public class CrewsService : BaseService<CrewDto, CrewRequest, int>, ICrewsService
    {
        public const string Ctrl_Name = "Crews";

        public Task<IEnumerable<CrewDto>> GetAllEntitiesAsync()
        {
            return base.GetAllEntities(Ctrl_Name);
        }

        public Task<CrewDto> CreateEntityAsync(CrewDto dto)
        {
            var request = new CrewRequest(dto);

            return base.CreateEntitiesAsync(request, Ctrl_Name);
        }

        public Task<bool> UpdateEntityByIdAsync(CrewDto dto)
        {
            var request = new CrewRequest(dto);

            return base.UpdateEntitiesByIdAsync(request, dto.Id, Ctrl_Name);
        }

        public Task<bool> DeleteEntityByIdAsync(int id)
        {
            return base.DeleteEntitiesByIdAsync(id, Ctrl_Name);
        }
    }
}
