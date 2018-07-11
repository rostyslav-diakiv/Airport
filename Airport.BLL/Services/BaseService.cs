namespace Airport.BLL.Services
{
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public abstract class BaseService
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        protected BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
