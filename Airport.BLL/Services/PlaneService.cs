namespace Airport.BLL.Services
{
    using System.Collections.Generic;
    using System.Net;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class PlaneService : BaseService<Plane, PlaneDto, PlaneRequest, int>, IPlaneService
    {
        public PlaneService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override IEnumerable<PlaneDto> GetAllEntity()
        {
            var s = uow.PlaneRepository.GetRange();

            var dtos = mapper.Map<List<Plane>, List<PlaneDto>>(s);

            return dtos;
        }

        public override PlaneDto GetEntityById(int id)
        {
            var entity = uow.PlaneRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override PlaneDto CreateEntity(PlaneRequest request)
        {
            var entity = mapper.Map<PlaneRequest, Plane>(request);

            entity = uow.PlaneRepository.Create(entity);

            return MapEntity(entity);
        }

        public override PlaneDto UpdateEntityById(PlaneRequest request, int id)
        {
            var planeType = uow.PlaneTypeRepository.GetFirstOrDefault(pt => pt.Id == request.PlaneTypeId);
            if (planeType == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Plane Type with id {request.PlaneTypeId} not found");
            }

            var entity = new Plane(request, planeType, id);

            var updated = uow.PlaneRepository.Update(entity);

            return MapEntity(updated);
        }

        public override bool DeleteEntityById(int id)
        {
            var e = uow.PlaneRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.PlaneRepository.Delete(e);
            if (!res)
            {
                return false;
            }

            e.PlaneType.Planes.Remove(e);
            foreach (var d in e.Departures)
            {
                d.Plane = null;
                d.PlaneId = 0;
            }
            
            return true;
        }
    }
}
