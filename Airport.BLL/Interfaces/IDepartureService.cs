namespace Airport.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface IDepartureService : IService<DepartureDto, DepartureRequest, int>
    {   
    }
}