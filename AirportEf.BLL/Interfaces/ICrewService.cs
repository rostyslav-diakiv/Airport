namespace AirportEf.BLL.Interfaces
{
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface ICrewService : IService<CrewDto, CrewRequest, int>
    {
        Task DownloadCrewsAsync();
    }
}