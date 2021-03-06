﻿namespace Airport.DAL
{
    using Airport.DAL.Data;
    using Airport.DAL.Interfaces;
    using Airport.DAL.Interfaces.Repositories;
    using Airport.DAL.Repositories;

    using AutoMapper;

    public class UnitOfWork : IUnitOfWork
    {
        private IStewardessRepository _stewardessRepository;
        private ICrewRepository _crewRepository;
        private IPilotRepository _pilotRepository;
        private IPlaneTypeRepository _planeTypeRepository;
        private IPlaneRepository _planeRepository;
        private IFlightRepository _flightRepository;
        private ITicketRepository _ticketRepository;
        private IDepartureRepository _departureRepository;

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

        public IPlaneTypeRepository PlaneTypeRepository
        {
            get
            {
                if (_planeTypeRepository == null)
                {
                    _planeTypeRepository = new PlaneTypeRepository(_provider.PlaneTypes, _mapper);
                }

                return _planeTypeRepository;
            }
        }

        public IPlaneRepository PlaneRepository
        {
            get
            {
                if (_planeRepository == null)
                {
                    _planeRepository = new PlaneRepository(_provider.Planes, _mapper);
                }

                return _planeRepository;
            }
        }

        public IFlightRepository FlightRepository
        {
            get
            {
                if (_flightRepository == null)
                {
                    _flightRepository = new FlightRepository(_provider.Flights, _mapper);
                }

                return _flightRepository;
            }
        }

        public ITicketRepository TicketRepository
        {
            get
            {
                if (_ticketRepository == null)
                {
                    _ticketRepository = new TicketRepository(_provider.Tickets, _mapper);
                }

                return _ticketRepository;
            }
        }

        public IDepartureRepository DepartureRepository
        {
            get
            {
                if (_departureRepository == null)
                {
                    _departureRepository = new DepartureRepository(_provider.Departures, _mapper);
                }

                return _departureRepository;
            }
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
