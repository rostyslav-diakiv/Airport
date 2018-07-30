namespace ClientLight.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Extensions;
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;

    using Windows.Security.Cryptography.Certificates;
    using Windows.Web.Http;
    using Windows.Web.Http.Filters;

    public class PilotService : BaseService<PilotDto, PilotRequest, int>, IPilotsService
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
                
                if (!msg.IsSuccessStatusCode) return null;

                var pilotDtos = await msg.Content.ReadAsJsonAsync<List<PilotDto>>();
                
                return pilotDtos;
            }
        }

        public async Task<PilotDto> CreatePilotAsync(PilotDto pilotDto)
        {
            var request = new PilotRequest()
                            {
                                Name = pilotDto.Name,
                                FamilyName = pilotDto.FamilyName,
                                DateOfBirth = pilotDto.DateOfBirth,
                                Experience = new TimeSpan(pilotDto.ExperienceAge.Years * 365, 0, 0, 0)
                            };

            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(
                ChainValidationResult.Untrusted |
                ChainValidationResult.InvalidName);

            using (var client = new HttpClient(filter))
            {
                var response = await client.PostAsJsonAsync(new Uri("http://localhost:10297/api/Pilots"), request);

                if (!response.IsSuccessStatusCode)
                {
                    return await OperateNonSuccessfullStatusCode(response);
                }

                var createdPilotDto = await response.Content.ReadAsJsonAsync<PilotDto>();

                return createdPilotDto;
            }
        }

        public async Task<bool> UpdatePilotByIdAsync(PilotDto pilotDto)
        {
            var request = new PilotRequest()
                              {
                                  Name = pilotDto.Name,
                                  FamilyName = pilotDto.FamilyName,
                                  DateOfBirth = pilotDto.DateOfBirth,
                                  Experience = new TimeSpan(pilotDto.ExperienceAge.Years * 365, 0, 0, 0)
                              };

            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(
                ChainValidationResult.Untrusted |
                ChainValidationResult.InvalidName);

            using (var client = new HttpClient(filter))
            {
                var response = await client.PutAsJsonAsync(new Uri($"http://localhost:10297/api/Pilots/{pilotDto.Id}"), request);

                if (!response.IsSuccessStatusCode)
                {
                    await OperateNonSuccessfullStatusCode(response);
                }

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeletePilotByIdAsync(int id)
        {
            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(
                ChainValidationResult.Untrusted |
                ChainValidationResult.InvalidName);

            using (var client = new HttpClient(filter))
            {
                var response = await client.DeleteAsync(new Uri($"http://localhost:10297/api/Pilots/{id}"));

                if (!response.IsSuccessStatusCode) return false;
                
                return true;
            }
        }
    }
}
