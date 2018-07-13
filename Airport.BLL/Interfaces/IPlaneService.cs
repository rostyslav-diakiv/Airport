namespace Airport.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface IPlaneService : IService<PlaneDto, PlaneRequest, int>
    {
    }
}