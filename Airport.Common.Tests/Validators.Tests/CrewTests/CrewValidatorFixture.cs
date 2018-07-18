namespace Airport.Common.Tests.Validators.Tests.CrewTests
{
    using Airport.Common.Validators;

    public class CrewValidatorFixture
    {
        public CrewValidator Validator { get; }

        public CrewValidatorFixture()
        {
            Validator = new CrewValidator();
        }
    }
}
