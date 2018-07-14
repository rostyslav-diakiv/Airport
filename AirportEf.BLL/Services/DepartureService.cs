namespace AirportEf.BLL.Services
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    public class DepartureService : BaseService<Departure, DepartureDto, DepartureRequest, int>, IDepartureService
    {
        public DepartureService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override async Task<IEnumerable<DepartureDto>> GetAllEntitiesAsync()
        {
            var departures = await uow.DepartureRepository.GetRangeAsync(include: dep => dep.Include(d => d.Crew)
                                                                                            .Include(d => d.Flight)
                                                                                            .Include(d => d.Plane));

            var dtos = mapper.Map<List<Departure>, List<DepartureDto>>(departures);

            return dtos;
        }

        public override async Task<DepartureDto> GetEntityByIdAsync(int id)
        {
            var entity = await uow.DepartureRepository.GetFirstOrDefaultAsync(s => s.Id == id, 
                                                                        include: dep => dep.Include(d => d.Crew)
                                                                                           .Include(d => d.Flight)
                                                                                           .Include(d => d.Plane));

            return MapEntity(entity);
        }

        public override async Task<DepartureDto> CreateEntityAsync(DepartureRequest request)
        {
            var entity = await InstantiateDepartureAsync(request);

            entity = await uow.DepartureRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            return MapEntity(entity);
        }

        public override async Task<bool> UpdateEntityByIdAsync(DepartureRequest request, int id)
        {
            var entity = await InstantiateUpdatedDepartureAsync(request, id);

            var updated = await uow.DepartureRepository.UpdateAsync(entity);
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await uow.DepartureRepository.DeleteAsync(id);

            var result = await uow.SaveAsync();

            return result;
        }

        public async Task<Departure> InstantiateDepartureAsync(DepartureRequest request)
        {
            var flight = await uow.FlightRepository.GetFirstOrDefaultAsync(f => f.Id == request.FlightNumber,
                                                                           disableTracking: false);
            if (flight == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Flight with number: {request.FlightNumber} doesn't exist");
            }

            var crew = await uow.CrewRepository.GetFirstOrDefaultAsync(c => c.Id == request.CrewId,
                                                                       disableTracking: false);
            if (crew == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Crew with id: {request.CrewId} doesn't exist");
            }

            var plane = await uow.PlaneRepository.GetFirstOrDefaultAsync(f => f.Id == request.PlaneId,
                                                                         disableTracking: false);
            if (plane == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Plane with id: {request.PlaneId} doesn't exist");
            }

            return new Departure(request, flight, crew, plane);
        }

        public async Task<Departure> InstantiateUpdatedDepartureAsync(DepartureRequest request, int id)
        {
            var flightEx = await uow.FlightRepository.ExistAsync(f => f.Id == request.FlightNumber);
            if (!flightEx)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Flight with number: {request.FlightNumber} doesn't exist");
            }

            var crewEx = await uow.CrewRepository.ExistAsync(c => c.Id == request.CrewId);
            if (!crewEx)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Crew with id: {request.CrewId} doesn't exist");
            }

            var planeEx = await uow.PlaneRepository.ExistAsync(f => f.Id == request.PlaneId);
            if (!planeEx)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Plane with id: {request.PlaneId} doesn't exist");
            }

            return new Departure(request, id);
        }
    }
}
