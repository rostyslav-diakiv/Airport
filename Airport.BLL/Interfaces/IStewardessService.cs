using Airport.Common.Dtos;

namespace Airport.BLL.Interfaces
{
    using Airport.Common.Requests;
    using Airport.DAL.Entities;

    public interface IStewardessService : IService<Stewardess, StewardessDto, StewardessRequest, int>
    {
    }
}