namespace Airport.Common.Tests.Validators.Tests.PlaneTests
{
    using Airport.Common.Validators;

    public class PlaneValidatorFixture
    {
        public PlaneValidator Validator { get; }

        public PlaneValidatorFixture() 
        {
            Validator = new PlaneValidator();
        }
    }
}
