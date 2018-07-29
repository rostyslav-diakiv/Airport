using System.Threading.Tasks;
using ClientLight.Model;

namespace ClientLight.Design
{
    public class DesignDataService : IDataService
    {
        public Task<DataItem> GetData()
        {
            // Use this to create design time data
            // When you in xaml editor you can use this data to set up, markup your views
            var item = new DataItem("Welcome to MVVM Light [design]");
            return Task.FromResult(item);
        }
    }
}