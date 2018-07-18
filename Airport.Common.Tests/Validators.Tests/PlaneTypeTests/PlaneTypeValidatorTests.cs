namespace Airport.Common.Tests.Validators.Tests.TicketTests
{
    using Airport.Common.Requests;
    using Airport.Common.Tests.Validators.Tests.PlaneTypeTests;

    using FluentValidation.TestHelper;

    using Xunit;

    public class PlaneTypeValidatorTests : IClassFixture<PlaneTypeValidatorFixture>
    {
        private readonly PlaneTypeValidatorFixture _fixure;

        public PlaneTypeValidatorTests(PlaneTypeValidatorFixture fixure)
        {
            _fixure = fixure;
        }

    }
}
