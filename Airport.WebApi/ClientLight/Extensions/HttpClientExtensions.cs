namespace ClientLight.Extensions
{
    using System;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using Windows.Foundation;
    using Windows.Storage.Streams;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;

    using HttpClient = Windows.Web.Http.HttpClient;
    using HttpResponseMessage = Windows.Web.Http.HttpResponseMessage;

    public static class HttpClientExtensions
    {
        public static IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> PostAsJsonAsync<T>(
            this HttpClient httpClient, Uri url, T data)
        {
            var dataAsString = JsonConvert.SerializeObject(data);
            var content = new HttpStringContent(dataAsString, UnicodeEncoding.Utf8, "application/json");
            content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json"); 
            return httpClient.PostAsync(url, content);
        }

        public static IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> PutAsJsonAsync<T>(
            this HttpClient httpClient, Uri url, T data)
        {
            var dataAsString = JsonConvert.SerializeObject(data);
            var content = new HttpStringContent(dataAsString, UnicodeEncoding.Utf8, "application/json");
            content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
            return httpClient.PutAsync(url, content);
        }

        public static async Task<T> ReadAsJsonAsync<T>(this IHttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dataAsString);
        }
    }
}
