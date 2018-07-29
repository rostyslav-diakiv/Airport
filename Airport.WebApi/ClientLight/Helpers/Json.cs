using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ClientLight.Helpers
{
    public static class Json
    {
        public static async Task<T> ToObjectAsync<T>(string value)
        {
            return await Task.Run<T>(() => JsonConvert.DeserializeObject<T>(value));
        }

        public static Task<string> StringifyAsync(object value)
        {
            return Task.Run<string>(() => JsonConvert.SerializeObject(value));
        }
    }
}
