namespace Airport.Common.Tests.Validators.Tests.DepartureTests
{
    using Airport.Common.Validators;

    public class DepartureValidatorFixture
    {
        public DepartureValidator Validator { get; }

        public DepartureValidatorFixture()
        {
            Validator = new DepartureValidator();
        }
    }
}
