namespace Airport.Common.Tests.Validators.Tests.PilotTests
{
    using Airport.Common.Requests;

    using FluentValidation.TestHelper;

    using Xunit;

    public class PilotValidatorTests : IClassFixture<PilotValidatorFixture>
    {
        private readonly PilotValidatorFixture _fixure;

        public PilotValidatorTests(PilotValidatorFixture fixure)
        {
            _fixure = fixure;
        }

  
    }
}
