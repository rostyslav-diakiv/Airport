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

    public class PlaneService : BaseService<Plane, PlaneDto, PlaneRequest, int>, IPlaneService
    {
        public PlaneService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override async Task<IEnumerable<PlaneDto>> GetAllEntitiesAsync()
        {
            var planes = await uow.PlaneRepository.GetRangeAsync(include: plane => plane.Include(p => p.PlaneType));

            var dtos = mapper.Map<List<Plane>, List<PlaneDto>>(planes);

            return dtos;
        }

        public override async Task<PlaneDto> GetEntityByIdAsync(int id)
        {
            var entity = await uow.PlaneRepository.GetFirstOrDefaultAsync(
                                        s => s.Id == id, 
                                        include: plane => plane.Include(p => p.PlaneType));

            return MapEntity(entity);
        }

        public override async Task<PlaneDto> CreateEntityAsync(PlaneRequest request)
        {
            var entity = await InstantiatePlaneAsync(request);

            entity = await uow.PlaneRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            return MapEntity(entity);
        }

        public override async Task<bool> UpdateEntityByIdAsync(PlaneRequest request, int id)
        {
            var entity = await InstantiateUpdatedPlaneAsync(request, id);
            
            var updated = await uow.PlaneRepository.UpdateAsync(entity);
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await uow.PlaneRepository.DeleteAsync(id); 

            var result = await uow.SaveAsync();

            return result;
        }

        public async Task<Plane> InstantiatePlaneAsync(PlaneRequest request)
        {
            var planeType = await uow.PlaneTypeRepository.GetFirstOrDefaultAsync(t => t.Id == request.PlaneTypeId, 
                                                                                   disableTracking: false);
            if (planeType == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Plane Type with Id: {request.PlaneTypeId} doesn't exist");
            }

            var entity = new Plane(request, planeType);

            return entity;
        }

        public async Task<Plane> InstantiateUpdatedPlaneAsync(PlaneRequest request, int id)
        {
            var planeTypeEx = await uow.PlaneTypeRepository.ExistAsync(t => t.Id == request.PlaneTypeId);
            if (!planeTypeEx)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Plane Type with Id: {request.PlaneTypeId} doesn't exist");
            }

            var entity = new Plane(request, id);

            return entity;
        }
    }
}
