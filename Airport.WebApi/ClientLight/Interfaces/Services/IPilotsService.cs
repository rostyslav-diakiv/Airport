namespace ClientLight.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Model;

    public interface IPilotsService
    {
        Task<IEnumerable<PilotDto>> GetAllPilots();

        Task<PilotDto> CreatePilotAsync(PilotDto pilotDto);

        Task<bool> UpdatePilotByIdAsync(PilotDto pilotDto);

        Task<bool> DeletePilotByIdAsync(int id);
    }
}