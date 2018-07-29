namespace ClientLight.Services
{
    // using System.Net.Http;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using Windows.Security.Cryptography.Certificates;
    using Windows.Web.Http;
    using Windows.Web.Http.Filters;

    using ClientLight.Model;

    public class PilotService
    {
        public PilotService() { }

        public async Task<IEnumerable<PilotDto>> GetAllPilots()
        {
            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(
                ChainValidationResult.Untrusted |
                ChainValidationResult.InvalidName);

            using (var client = new HttpClient(filter))
            {
                HttpResponseMessage msg = await client.GetAsync(new Uri("http://localhost:10297/api/Pilots"));

                // HttpResponseMessage msg = await client.GetAsync(new Uri("https://localhost:5001/api/Pilots"));

                if (!msg.IsSuccessStatusCode) return null;

                var serializedPilots = await msg.Content.ReadAsStringAsync();

                var pilotDtos = JsonConvert.DeserializeObject<List<PilotDto>>(serializedPilots);

                return pilotDtos;
            }
        }
    }
}
