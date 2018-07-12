namespace Airport.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface ICrewService : IService<CrewDto, CrewRequest, int>
    {
    }
}