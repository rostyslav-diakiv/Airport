namespace AirportEf.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.DAL.Entities;

    public interface IPlaneTypeService : IService<PlaneType, PlaneTypeDto, PlaneTypeRequest, int>
    {
    }
}
