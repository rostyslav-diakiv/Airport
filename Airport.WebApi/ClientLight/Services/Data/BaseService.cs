namespace ClientLight.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Extensions;
    using ClientLight.Helpers;

    using Windows.Web.Http;

    public abstract class BaseService<TDto, TRequest, TKey> 
    {
        public virtual async Task<IEnumerable<TDto>> GetAllEntities(string ctrl)
        {
            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var msg = await client.GetAsync(new Uri($"http://localhost:10297/api/{ctrl}"));

                if (!msg.IsSuccessStatusCode) return null;

                var dtos = await msg.Content.ReadAsJsonAsync<List<TDto>>();

                return dtos;
            }
        }

        public virtual async Task<TDto> CreateEntitiesAsync(TRequest request, string ctrl)
        {
            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var response = await client.PostAsJsonAsync(new Uri($"http://localhost:10297/api/{ctrl}"), request);

                if (!response.IsSuccessStatusCode) return default(TDto);

                var dto = await response.Content.ReadAsJsonAsync<TDto>();

                return dto;
            }
        }

        public virtual async Task<bool> UpdateEntitiesByIdAsync(TRequest request, TKey id, string ctrl)
        {
            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var response = await client.PutAsJsonAsync(new Uri($"http://localhost:10297/api/{ctrl}/{id}"), request);

                return response.IsSuccessStatusCode;
            }
        }

        public virtual async Task<bool> DeleteEntitiesByIdAsync(TKey id, string ctrl)
        {
            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var response = await client.DeleteAsync(new Uri($"http://localhost:10297/api/{ctrl}/{id}"));

                return response.IsSuccessStatusCode;
            }
        }
    }
}
