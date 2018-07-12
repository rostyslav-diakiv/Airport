namespace AirportEf.DAL
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AirportEf.DAL.Data;
    using AirportEf.DAL.Interfaces;
    using AirportEf.DAL.Interfaces.Repositories;
    using AirportEf.DAL.Repositories;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    public class UnitOfWork : IUnitOfWork
    {
        private IStewardessRepository _stewardessRepository;
        private ICrewRepository _crewRepository;
        private IPilotRepository _pilotRepository;

        private readonly AirportDbContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(AirportDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IStewardessRepository StewardessRepository
        {
            get
            {
                if (_stewardessRepository == null)
                {
                    _stewardessRepository = new StewardessRepository(_context, _mapper);
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
                    _pilotRepository = new PilotRepository(_context, _mapper);
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
                    _crewRepository = new CrewRepository(_context, _mapper);
                }

                return _crewRepository;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                var changes = _context.ChangeTracker.Entries().Count(
                    p => p.State == EntityState.Modified || p.State == EntityState.Deleted
                                                         || p.State == EntityState.Added);
                if (changes == 0) return true;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // DbSet?.Local?.Clear();
                    _context?.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.


                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AbstractRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
