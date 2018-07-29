namespace ClientLight.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;

    public class StewardessesService : BaseService<StewardessDto, StewardessRequest, int>, IStewardessesService
    {
        public const string Ctrl_Name = "Stewardesses";

        public Task<IEnumerable<StewardessDto>> GetAllEntities()
        {
            return base.GetAllEntities(Ctrl_Name);
        }

        public Task<StewardessDto> CreateEntitiesAsync(StewardessDto dto)
        {
            var request = new StewardessRequest(dto);

            return base.CreateEntitiesAsync(request, Ctrl_Name);
        }

        public Task<bool> UpdateEntitiesByIdAsync(StewardessDto dto)
        {
            var request = new StewardessRequest(dto);

            return base.UpdateEntitiesByIdAsync(request, dto.Id, Ctrl_Name);
        }

        public Task<bool> DeleteEntitiesByIdAsync(int id)
        {
            return base.DeleteEntitiesByIdAsync(id, Ctrl_Name);
        }
    }
}
