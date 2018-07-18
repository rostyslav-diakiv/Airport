namespace Airport.Common.Tests.Validators.Tests.PlaneTests
{
    using Airport.Common.Requests;
    using Airport.Common.Tests.Validators.Tests.TicketTests;

    using FluentValidation.TestHelper;

    using Xunit;

    public class PlaneValidatorTests : IClassFixture<PlaneValidatorFixture>
    {
        private readonly PlaneValidatorFixture _fixure;

        public PlaneValidatorTests(PlaneValidatorFixture fixure)
        {
            _fixure = fixure;
        }

    
    }
}
