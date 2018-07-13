namespace Airport.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface IFlightService : IService<FlightDto, FlightRequest, string>
    {
    }
}