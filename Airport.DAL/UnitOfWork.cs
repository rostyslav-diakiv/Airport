namespace Airport.DAL
{
    using Airport.DAL.Interfaces;
    using Airport.DAL.Interfaces.Repositories;
    using Airport.DAL.Repositories;

    using AutoMapper;

    public class UnitOfWork : IUnitOfWork
    {
        private IStewardessRepository _stewardessRepository;
        private ICrewRepository _crewRepository;
        private IPilotRepository _pilotRepository;


        private readonly IDataProvider _provider;
        private readonly IMapper _mapper;

        public UnitOfWork(IDataProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public IStewardessRepository StewardessRepository
        {
            get
            {
                if (_stewardessRepository == null)
                {
                    _stewardessRepository = new StewardessRepository(_provider.Stewardesses, _mapper);
                }

                return _stewardessRepository;
            }
        }

        public IPilotRepository PilotRepository
        {
            get
            {
                if (_pilotRepository == null)
                {
                    _pilotRepository = new PilotRepository(_provider.Pilots, _mapper);
                }

                return _pilotRepository;
            }
        }

        public ICrewRepository CrewRepository
        {
            get
            {
                if (_crewRepository == null)
                {
                    _crewRepository = new CrewRepository(_provider.Crews, _mapper);
                }

                return _crewRepository;
            }
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
