namespace Airport.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;

    public interface ICrewService : IService<Crew, CrewDto, CrewRequest, int>
    {
    }
}