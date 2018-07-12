namespace AirportEf.BLL.Services
{
    using System.Collections.Generic;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    public abstract class BaseService<TDto, TRequest, TKey> : IService<TDto, TRequest, TKey>
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        protected BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public abstract IEnumerable<TDto> GetAllEntity();

        public abstract TDto GetEntityById(TKey id);

        public abstract TDto CreateEntity(TRequest request);

        public abstract TDto UpdateEntityById(TRequest request, TKey id);

        public abstract bool DeleteEntityById(TKey id);
    }
}
