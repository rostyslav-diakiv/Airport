namespace Airport.Common.Tests.Validators.Tests.CrewTests
{
    using Xunit;

    public class CrewValidatorTests : IClassFixture<CrewValidatorFixture>
    {
        private readonly CrewValidatorFixture _fixure;

        public CrewValidatorTests(CrewValidatorFixture fixure)
        {
            _fixure = fixure;
        }
    }
}
