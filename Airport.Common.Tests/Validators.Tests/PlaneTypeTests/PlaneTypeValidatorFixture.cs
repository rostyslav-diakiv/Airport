namespace Airport.Common.Tests.Validators.Tests.PlaneTypeTests
{
    using Airport.Common.Validators;

    public class PlaneTypeValidatorFixture
    {
        public PlaneTypeValidator Validator { get; }

        public PlaneTypeValidatorFixture() 
        {
            Validator = new PlaneTypeValidator();
        }
    }
}
