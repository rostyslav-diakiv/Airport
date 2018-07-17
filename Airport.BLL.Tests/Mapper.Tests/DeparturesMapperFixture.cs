namespace Airport.BLL.Tests.Services.Tests.TestsSetup
{
    using System;

    using AirportEf.BLL.Mapper;

    using AutoMapper;

    public class DeparturesMapperFixture : IDisposable
    {
        public IMapper DeparturesMapper { get; }

        public DeparturesMapperFixture()
        {
            // Arrange Real for testing
            var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DeparturesProfile>();
                    cfg.AddProfile<FlightsProfile>();
                });

            DeparturesMapper = new Mapper(configuration);

            Mapper.Reset();
            Mapper.Initialize(
                cfg =>
                    {
                        cfg.AddProfile<DeparturesProfile>();
                        cfg.AddProfile<FlightsProfile>();
                    });
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Mapper.Reset();
        }
    }
}
