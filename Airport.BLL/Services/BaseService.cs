namespace Airport.BLL.Services
{
    using System.Collections.Generic;

    using Airport.BLL.Interfaces;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public abstract class BaseService<TDto, TRequest, TKey> : IService<TDto, TRequest, TKey>
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;

        protected BaseService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public abstract IEnumerable<TDto> GetAllEntity();

        public abstract TDto GetEntityById(TKey id);

        public abstract TDto CreateEntity(TRequest request);

        public abstract TDto UpdateEntityById(TRequest request, TKey id);

        public abstract bool DeleteEntityById(TKey id);
    }
}
