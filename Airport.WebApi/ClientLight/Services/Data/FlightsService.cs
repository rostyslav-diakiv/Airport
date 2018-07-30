namespace ClientLight.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;
    public class FlightsService : BaseService<FlightDto, FlightRequest, string>, IFlightsService
    {
        public const string Ctrl_Name = "Flights";

        public Task<IEnumerable<FlightDto>> GetAllEntitiesAsync()
        {
            return base.GetAllEntities(Ctrl_Name);
        }
        public Task<FlightDto> CreateEntityAsync(FlightDto dto)
        {
            dto.Number = GetGeneratedNumber();
            var request = new FlightRequest(dto);

            return base.CreateEntitiesAsync(request, Ctrl_Name);
        }

        public Task<bool> UpdateEntityByIdAsync(FlightDto dto)
        {
            var request = new FlightRequest(dto);

            return base.UpdateEntitiesByIdAsync(request, dto.Id, Ctrl_Name);
        }

        public Task<bool> DeleteEntityByIdAsync(string id)
        {
            return base.DeleteEntitiesByIdAsync(id, Ctrl_Name);
        }


        private static Random random = new Random();
        private string GetGeneratedNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 7) // Length of number = 7
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
