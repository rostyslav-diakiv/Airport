namespace Airport.BLL.Interfaces
{
    using System.Collections.Generic;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface ICrewService
    {
        CrewDto CreateCrew(CrewRequest request);
        bool DeleteCrewById(int id);
        IEnumerable<CrewDto> GetAllCrews();
        CrewDto GetCrewById(int id);
        CrewDto UpdateCrewById(CrewRequest request, int id);
    }
}