namespace Airport.Common.Tests.Validators.Tests.FlightsTests
{
    using Airport.Common.Requests;

    using FluentValidation.TestHelper;

    using Xunit;

    public class FlightValidatorTests : IClassFixture<FlightValidatorFixture>
    {
        private readonly FlightValidatorFixture _fixure;

        public FlightValidatorTests(FlightValidatorFixture fixure)
        {
            _fixure = fixure;
        }

  
    }
}
