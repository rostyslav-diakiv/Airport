namespace AirportEf.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    public class PlaneTypeService : BaseService<PlaneType, PlaneTypeDto, PlaneTypeRequest, int>, IPlaneTypeService
    {
        public PlaneTypeService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override async Task<IEnumerable<PlaneTypeDto>> GetAllEntitiesAsync()
        {
            var types = await uow.PlaneTypeRepository.GetRangeAsync();

            var dtos = mapper.Map<List<PlaneType>, List<PlaneTypeDto>>(types);

            return dtos;
        }

        public override async Task<PlaneTypeDto> GetEntityByIdAsync(int id)
        {
            var entity = await uow.PlaneTypeRepository.GetFirstOrDefaultAsync(s => s.Id == id);

            return MapEntity(entity);
        }

        public override async Task<PlaneTypeDto> CreateEntityAsync(PlaneTypeRequest request)
        {
            var entity = mapper.Map<PlaneTypeRequest, PlaneType>(request);

            entity = await uow.PlaneTypeRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            return MapEntity(entity);
        }

        public override async Task<bool> UpdateEntityByIdAsync(PlaneTypeRequest request, int id)
        {
            var entity = new PlaneType(request, id);

            var updated = await uow.PlaneTypeRepository.UpdateAsync(entity);
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await uow.PlaneTypeRepository.DeleteAsync(id);
            var result = await uow.SaveAsync();

            return result;
        }
    }
}
