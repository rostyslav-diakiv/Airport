namespace Airport.Common.Tests.Validators.Tests.FlightsTests
{
    using Airport.Common.Validators;

    public class FlightValidatorFixture
    {
        public FlightValidator Validator { get; }

        public FlightValidatorFixture()
        {
            Validator = new FlightValidator();
        }
    }
}
