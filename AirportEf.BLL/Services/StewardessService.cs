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

    public class StewardessService : BaseService<Stewardess, StewardessDto, StewardessRequest, int>, IStewardessService
    {
        public StewardessService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override async Task<IEnumerable<StewardessDto>> GetAllEntitiesAsync()
        {
            var stewardesses = await uow.StewardessRepository.GetRangeAsync();

            var dtos = mapper.Map<List<Stewardess>, List<StewardessDto>>(stewardesses);

            return dtos;
        }

        public override async Task<StewardessDto> GetEntityByIdAsync(int id)
        {
            var entity = await uow.StewardessRepository.GetFirstOrDefaultAsync(s => s.Id == id);

            return MapEntity(entity);
        }

        public override async Task<StewardessDto> CreateEntityAsync(StewardessRequest request)
        {
            var entity = mapper.Map<StewardessRequest, Stewardess>(request);

            entity = await uow.StewardessRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            return MapEntity(entity);
        }

        public override async Task<bool> UpdateEntityByIdAsync(StewardessRequest request, int id)
        {
            var entity = new Stewardess(request, id);

            var updated = await uow.StewardessRepository.UpdateAsync(entity);
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await uow.StewardessRepository.DeleteAsync(id);
            var result = await uow.SaveAsync();

            return result;
        }
    }
}
