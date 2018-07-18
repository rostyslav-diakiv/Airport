namespace Airport.Common.Tests.Validators.Tests.StewardessTests
{
    using Airport.Common.Validators;

    public class StewardessValidatorFixture
    {
        public StewardessValidator Validator { get; }

        public StewardessValidatorFixture() 
        {
            Validator = new StewardessValidator();
        }
    }
}
