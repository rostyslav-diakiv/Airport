namespace Airport.BLL.Tests.Services.Tests.TestsSetup
{
    using System;

    using AirportEf.BLL.Utils;
    using AirportEf.DAL;
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Interfaces;

    using Microsoft.EntityFrameworkCore;

    public class IntegrationFixture : ServicesFixture, IDisposable
    {
        public IUnitOfWork Uow { get; }

        public IntegrationFixture() : base()
        {
            var options = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase(databaseName: "CRUTest")
                .Options;
            var context = new AirportDbContext(options);
            DatabaseSeeder.SeedAction(context);

            Uow = new UnitOfWork(context, ConfMapper);
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                Uow?.Dispose();
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.</summary>
        ~IntegrationFixture()
        {
            Dispose(false);
        }
    }
}
