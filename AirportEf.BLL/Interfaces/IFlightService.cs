namespace AirportEf.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface IFlightService : IService<FlightDto, FlightRequest, string>
    {
        Task<List<FlightDto>> GetAllEntitiesDelayedAsync(int delayMs);
    }
}