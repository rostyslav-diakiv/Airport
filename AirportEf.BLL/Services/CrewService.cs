namespace AirportEf.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;

    public class CrewService : BaseService<Crew, CrewDto, CrewRequest, int>, ICrewService
    {
        private readonly IHostingEnvironment _environment;

        public CrewService(IUnitOfWork uow, IMapper mapper, IHostingEnvironment environment)
            : base(uow, mapper)
        {
            _environment = environment;
        }

        public override async Task<IEnumerable<CrewDto>> GetAllEntitiesAsync()
        {
            var entity = await uow.CrewRepository.GetRangeAsync(include: cr => cr.Include(c => c.Pilot)
                                                                                 .Include(c => c.CrewStewardess)
                                                                                       .ThenInclude(c => c.Stewardess));
            var dtos = mapper.Map<List<Crew>, List<CrewDto>>(entity);

            return dtos;
        }

        public override async Task<CrewDto> GetEntityByIdAsync(int id)
        {
            var entity = await uow.CrewRepository.GetFirstOrDefaultAsync(
                                                    s => s.Id == id, 
                                                    include: cr => cr.Include(c => c.Pilot)
                                                                     .Include(c => c.CrewStewardess)
                                                                        .ThenInclude(c => c.Stewardess));

            return MapEntity(entity);
        }

        public override async Task<CrewDto> CreateEntityAsync(CrewRequest request)
        {
            var entity = await InstantiateCrewAsync(request);

            entity = await uow.CrewRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            return MapEntity(entity);
        }
        
        public override async Task<bool> UpdateEntityByIdAsync(CrewRequest request, int id)
        {
            var entity = await InstantiateUpdateCrewAsync(request, id);

            var updated = await uow.CrewRepository.UpdateAsync(entity, crews => crews.Include(c => c.CrewStewardess));
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await uow.CrewRepository.DeleteAsync(id);
            var result = await uow.SaveAsync();

            return result;
        }

        private async void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            await Task.Delay(1000);
        }

        public async Task DownloadCrewsAsync()
        {
            // Fetch and Join data
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler) { BaseAddress = new Uri("http://5b128555d50a5c0014ef1204.mockapi.io/") })
            {
                var crewsTask = await client.GetAsync("crew");

                if (!crewsTask.IsSuccessStatusCode) return;

                var serializedCrews = await crewsTask.Content.ReadAsStringAsync();

                var crewsDtos = JsonConvert.DeserializeObject<IEnumerable<CrewApiDto>>(serializedCrews).Take(10).ToList();

                var writeTask = WriteCsvFileAsync(crewsDtos); 
                
                var crews = mapper.Map<List<CrewApiDto>, List<Crew>>(crewsDtos);

                foreach (var c in crews)
                {
                    foreach (var cs in c.CrewStewardess)
                    {
                        cs.Crew = c;
                    }
                }

                await uow.CrewRepository.CreateManyAsync(crews);
                var saveTask = uow.SaveAsync();

                await Task.WhenAll(saveTask, writeTask);
            }
        }

        private async Task WriteCsvFileAsync(List<CrewApiDto> crewsDtos)
        {
            var (path, sb)  = await CreateStreamBuilderAndFilePath(crewsDtos);
            await File.WriteAllTextAsync(path, sb.ToString());
        }

        private Task<(string filePath, StringBuilder stringBuilder)> CreateStreamBuilderAndFilePath(List<CrewApiDto> crewsDtos)
        {
            return Task.Run(
                () =>
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Crew Id,Pilot Id,Pilot Crew Id, Pilot First Name, Pilot Last Name, Pilot Experience, Pilot Birth Date|,"
                                      + " Stewardess Id, Stewardess Crew Id, Stewardess First Name, Stewardess Last Name, Stewardess Birth Date");
                        foreach (var c in crewsDtos)
                        {
                            var pilotSection = $"{c.Pilot[0].Id },{ c.Pilot[0].CrewId},{ c.Pilot[0].FirstName},{ c.Pilot[0].LastName},{ c.Pilot[0].Exp},{ c.Pilot[0].BirthDate}";
                            var stewardessSection = $"{c.Stewardess[0].Id},{c.Stewardess[0].CrewId},{c.Stewardess[0].FirstName},{c.Stewardess[0].LastName},{c.Stewardess[0].BirthDate}";
                            sb.AppendLine($"{c.Id},{pilotSection},{stewardessSection}");
                            foreach (var s in c.Stewardess.Skip(1))
                            {
                                sb.AppendLine($",,,,,,,{s.Id},{s.CrewId},{s.FirstName},{s.LastName},{s.BirthDate}");
                            }
                        }

                        var pathToFiles = Path.Combine(_environment.ContentRootPath, "CsvFiles");
                        if (!Directory.Exists(Path.Combine(pathToFiles)))
                        {
                            Directory.CreateDirectory(pathToFiles);
                        }
                        
                        pathToFiles = Path.Combine(pathToFiles, $"crews-{DateTime.UtcNow:yyyy-dd-M--HH-mm-ss}.csv");
                        
                        return (pathToFiles, sb);
                    });
        }

        private async Task<Crew> InstantiateCrewAsync(CrewRequest request)
        {
            // Remove identical Ids from collection
            request.StewardessesIds = request.StewardessesIds.Distinct().ToList();
            
            var sts = await uow.StewardessRepository.GetRangeAsync(
                          count: request.StewardessesIds.Count(),
                          filter: s => request.StewardessesIds.Contains(s.Id),
                          disableTracking: false);

            if (sts.Count < request.StewardessesIds.Count())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "One or more Stewardesses with such ids not found");
            }

            var pilot = await uow.PilotRepository.GetFirstOrDefaultAsync(p => p.Id == request.PilotId,
                                                                           disableTracking: false);
            if (pilot == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Pilot with id: {request.PilotId} not found");
            }

            var entity = new Crew()
            {
                Pilot = pilot,
                PilotId = pilot.Id,
                Departures = new List<Departure>(),
                CrewStewardess = new List<CrewStewardess>()
            };

            foreach (var s in sts)
            {
                entity.CrewStewardess.Add(new CrewStewardess()
                {
                    Crew = entity,
                    Stewardess = s
                });
            }

            return entity;
        }

        private async Task<Crew> InstantiateUpdateCrewAsync(CrewRequest request, int id)
        {
            // Remove identical Ids from collection
            request.StewardessesIds = request.StewardessesIds.Distinct().ToList();

            var stsEx = await uow.StewardessRepository.CountAsync(s => request.StewardessesIds.Contains(s.Id));
            if (stsEx < request.StewardessesIds.Count())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "One or more Stewardesses with such ids not found");
            }

            var pilotEx = await uow.PilotRepository.ExistAsync(p => p.Id == request.PilotId);
            if (!pilotEx)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Pilot with id: {request.PilotId} not found");
            }

            var entity = new Crew()
                             {
                                 Id = id,
                                 PilotId = request.PilotId,
                                 Departures = new List<Departure>(),
                                 CrewStewardess = new List<CrewStewardess>()
                             };

            foreach (var s in request.StewardessesIds)
            {
                entity.CrewStewardess.Add(new CrewStewardess()
                                              {
                                                  CrewId = entity.Id,
                                                  StewardessId = s
                                              });
            }

            return entity;
        }
    }
}
