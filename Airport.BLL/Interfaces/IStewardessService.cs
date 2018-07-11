using System.Collections.Generic;
using Airport.Common.Dtos;

namespace Airport.BLL.Interfaces
{
    using Airport.Common.Requests;

    public interface IStewardessService
    {
        IEnumerable<StewardessDto> GetAllStewardesses();

        StewardessDto GetStewardessById(int id);

        StewardessDto CreateStewardess(StewardessRequest request);

        StewardessDto UpdateStewardessById(StewardessRequest request, int id);

        bool DeleteStewardessById(int id);
    }
}