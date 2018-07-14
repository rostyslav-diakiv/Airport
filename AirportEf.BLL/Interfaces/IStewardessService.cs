namespace AirportEf.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.DAL.Entities;

    public interface IStewardessService : IService<Stewardess, StewardessDto, StewardessRequest, int>
    {
    }
}