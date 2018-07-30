namespace ClientLight.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Windows.Web.Http;

    using ClientLight.Extensions;
    using ClientLight.Helpers;
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;
    public class CrewsService : BaseService<CrewVmDto, CrewRequest, int>, ICrewsService
    {
        public const string Ctrl_Name = "Crews";

        public async Task<IEnumerable<CrewVmDto>> GetAllEntitiesAsync()
        {
            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var msg = await client.GetAsync(new Uri($"http://localhost:10297/api/{Ctrl_Name}"));

                if (!msg.IsSuccessStatusCode) return null;

                var dtos = await msg.Content.ReadAsJsonAsync<List<CrewDto>>();

                var vmDtos = dtos.Select(c => new CrewVmDto(c)).ToList();

                return vmDtos;
            }
        }

        public Task<CrewVmDto> CreateEntityAsync(CrewVmDto dto)
        {
            var request = new CrewRequest(dto);

            return base.CreateEntitiesAsync(request, Ctrl_Name);
        }

        public Task<bool> UpdateEntityByIdAsync(CrewVmDto dto)
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
