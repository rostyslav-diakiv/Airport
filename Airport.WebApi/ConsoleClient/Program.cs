using System;

namespace ConsoleClient
{
    using System.Net.Http;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(20000);
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler) { BaseAddress = new Uri("http://localhost:5000/api/") })
            {
                var crewsTask = client.GetAsync("Pilots").Result;

                if (!crewsTask.IsSuccessStatusCode) // return null;

                {
                    string serializedPilots;
                    serializedPilots = crewsTask.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(serializedPilots);
                }

           

                // var pilotDtos = JsonConvert.DeserializeObject<List<PilotDto>>(serializedPilots);

               // return null;
            }
        }
    }
}
