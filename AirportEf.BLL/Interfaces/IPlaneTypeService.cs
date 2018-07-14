namespace AirportEf.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface IPlaneTypeService : IService<PlaneTypeDto, PlaneTypeRequest, int>
    {
    }
}
