namespace Airport.BLL.Tests.Mapper.Tests
{
    using Airport.BLL.Tests.Services.Tests.TestsSetup;

    using Xunit;

    [Collection("Common Services Collection")]
    public class TicketsProfileTests
    {
        private readonly ServicesFixture _servicesFixture;

        public TicketsProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }
    }
}
