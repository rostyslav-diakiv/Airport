namespace Airport.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;

    public interface IFlightService : IService<Flight, FlightDto, FlightRequest, string>
    {
    }
}