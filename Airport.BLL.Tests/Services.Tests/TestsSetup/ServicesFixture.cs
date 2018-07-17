namespace Airport.BLL.Tests.Services.Tests.TestsSetup
{
    using AirportEf.BLL.Mapper;

    using AutoMapper;

    public class ServicesFixture
    {
        public IMapper ConfMapper { get; }

        public ServicesFixture()
        {
            // Arrange Real for testing
            var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new CrewsProfile());
                    cfg.AddProfile(new DeparturesProfile());
                    cfg.AddProfile(new FlightsProfile());
                    cfg.AddProfile(new PilotsProfile());
                    cfg.AddProfile(new PlanesProfile());
                    cfg.AddProfile(new PlaneTypesProfile());
                    cfg.AddProfile(new StewardessProfile());
                    cfg.AddProfile(new TicketsProfile());
                });

            ConfMapper = new Mapper(configuration);
        }
    }
}
