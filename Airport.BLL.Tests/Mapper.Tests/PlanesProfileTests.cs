namespace Airport.BLL.Tests.Mapper.Tests
{
    using Airport.BLL.Tests.Services.Tests.TestsSetup;

    using Xunit;

    [Collection("Common Services Collection")]
    public class PlanesProfileTests
    {
        private readonly ServicesFixture _servicesFixture;

        public PlanesProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }
    }
}
