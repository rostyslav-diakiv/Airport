namespace Airport.BLL.Services
{
    using System.Collections.Generic;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class PlaneTypeService : BaseService<PlaneType, PlaneTypeDto, PlaneTypeRequest, int>, IPlaneTypeService
    {
        public PlaneTypeService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override IEnumerable<PlaneTypeDto> GetAllEntity()
        {
            var s = uow.PlaneTypeRepository.GetRange();

            var dtos = mapper.Map<List<PlaneType>, List<PlaneTypeDto>>(s);

            return dtos;
        }

        public override PlaneTypeDto GetEntityById(int id)
        {
            var entity = uow.PlaneTypeRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override PlaneTypeDto CreateEntity(PlaneTypeRequest request)
        {
            var entity = mapper.Map<PlaneTypeRequest, PlaneType>(request);

            entity = uow.PlaneTypeRepository.Create(entity);

            return MapEntity(entity);
        }

        public override PlaneType UpdateEntityById(PlaneTypeRequest request, int id)
        {
            var entity = new PlaneType(request, id);

            var updated = uow.PlaneTypeRepository.Update(entity);

            return updated;
        }

        public override bool DeleteEntityById(int id)
        {
            var e = uow.PlaneTypeRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.PlaneTypeRepository.Delete(e);
            if (!res)
            {
                return false;
            }
            
            foreach (var c in e.Planes)
            {
                c.PlaneType = null;
                c.PlaneTypeId = 0;
            }

            return true;
        }
    }
}
