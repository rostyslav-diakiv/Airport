namespace Airport.Common.Tests.Validators.Tests.PilotTests
{
    using Airport.Common.Validators;

    public class PilotValidatorFixture
    {
        public PilotValidator Validator { get; }

        public PilotValidatorFixture() 
        {
            Validator = new PilotValidator();
        }
    }
}
