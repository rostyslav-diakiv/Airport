using System.Threading.Tasks;

namespace ClientLight.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}