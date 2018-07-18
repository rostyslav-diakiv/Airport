namespace Airport.Common.Tests.Validators.Tests.DepartureTests
{
    using Airport.Common.Requests;

    using FluentValidation.TestHelper;

    using Xunit;

    public class DepartureValidatorTests : IClassFixture<DepartureValidatorFixture>
    {
        private readonly DepartureValidatorFixture _fixure;

        public DepartureValidatorTests(DepartureValidatorFixture fixure)
        {
            _fixure = fixure;
        }

  
    }
}
