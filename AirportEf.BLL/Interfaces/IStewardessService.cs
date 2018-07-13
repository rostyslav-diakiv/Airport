namespace AirportEf.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface IStewardessService : IService<StewardessDto, StewardessRequest, int>
    {
    }
}