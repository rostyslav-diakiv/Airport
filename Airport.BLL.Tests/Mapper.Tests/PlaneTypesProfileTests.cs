namespace Airport.BLL.Tests.Mapper.Tests
{
    using Airport.BLL.Tests.Services.Tests.TestsSetup;

    using Xunit;

    [Collection("Common Services Collection")]
    public class PlaneTypesProfileTests
    {
        private readonly ServicesFixture _servicesFixture;

        public PlaneTypesProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }
    }
}
