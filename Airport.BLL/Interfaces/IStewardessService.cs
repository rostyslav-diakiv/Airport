using Airport.Common.Dtos;

namespace Airport.BLL.Interfaces
{
    using Airport.Common.Requests;

    public interface IStewardessService : IService<StewardessDto, StewardessRequest, int>
    {
    }
}