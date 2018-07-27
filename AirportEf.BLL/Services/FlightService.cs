namespace AirportEf.BLL.Services
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Timers;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    public class FlightService : BaseService<Flight, FlightDto, FlightRequest, string>, IFlightService
    {
        public FlightService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override async Task<IEnumerable<FlightDto>> GetAllEntitiesAsync()
        {
            // await DelayAsync(5); // Delay request for 5 seconds

            var flights = await uow.FlightRepository.GetRangeAsync();

            var dtos = mapper.Map<List<Flight>, List<FlightDto>>(flights);

            return dtos;
        }

        public Task<List<FlightDto>> GetAllEntitiesDelayedAsync(int delayMs)
        {
            var taskCompletionSource = new TaskCompletionSource<List<FlightDto>>();

            var timer = new Timer(delayMs) { AutoReset = false };

            timer.Elapsed += async delegate
                {
                    timer.Dispose();
                    var flights = await uow.FlightRepository.GetRangeAsync();

                    var dtos = mapper.Map<List<Flight>, List<FlightDto>>(flights);

                    taskCompletionSource.SetResult(dtos);
                };

            timer.Start();

            return taskCompletionSource.Task;
        }

        public override async Task<FlightDto> GetEntityByIdAsync(string id)
        {
            var entity = await uow.FlightRepository.GetFirstOrDefaultAsync(s => s.Id == id);

            return MapEntity(entity);
        }

        public override async Task<FlightDto> CreateEntityAsync(FlightRequest request)
        {
            var exists = await uow.FlightRepository.ExistAsync(f => f.Id == request.Number);
            if (exists)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Flight with number: {request.Number} already exists");
            }

            var entity = mapper.Map<FlightRequest, Flight>(request);

            entity = await uow.FlightRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            return MapEntity(entity);
        }

        public override async Task<bool> UpdateEntityByIdAsync(FlightRequest request, string id)
        {
            if (request.Number != id)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, 
                    "Flight number in the route doesn't match number in the model! Please input equals numbers");
            }

            var entity = new Flight(request, id);

            var updated = await uow.FlightRepository.UpdateAsync(entity);
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(string id)
        {
            await uow.FlightRepository.DeleteAsync(id); 

            var result = await uow.SaveAsync();

            return result;
        }

        private Task DelayAsync(int seconds)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();

            var timer = new System.Timers.Timer(seconds * 1000) { AutoReset = false };

            timer.Elapsed += delegate
                {
                    timer.Dispose();
                    taskCompletionSource.SetResult(null);
                };

            timer.Start();

            return taskCompletionSource.Task;
        }
    }
}
