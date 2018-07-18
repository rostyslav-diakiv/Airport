namespace Airport.Common.Tests.Validators.Tests.TicketTests
{
    using Airport.Common.Requests;

    using FluentValidation.TestHelper;

    using Xunit;

    public class TicketValidatorTests : IClassFixture<TicketValidatorFixture>
    {
        private readonly TicketValidatorFixture _fixure;

        public TicketValidatorTests(TicketValidatorFixture fixure)
        {
            _fixure = fixure;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-105)]
        [InlineData(4)]
        [InlineData(int.MaxValue)]
        [InlineData(9999999999999)]
        public void Should_have_error_when_Price_length_is_Less_Than_5_And_Greater_That_10(decimal price)
        {
            var ticket = new TicketRequest { Price = price, FlightNumber = "AFDET324" };
            _fixure.Validator.ShouldHaveValidationErrorFor(t => t.Price, ticket);
        }

        [Theory]
        [InlineData("wer")]
        [InlineData("SBEYD678DBS97")]
        [InlineData("-2")]
        public void Should_have_error_when_Number_Length_is_Less_Than_5_And_Greater_Than_10(string number)
        {
            var ticket = new TicketRequest { Price = 1000, FlightNumber = number };
            _fixure.Validator.ShouldHaveValidationErrorFor(t => t.FlightNumber, ticket);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(3000)]
        [InlineData(100000)]
        public void Should_not_have_error_when_Price_InclusiveBetween_5_And_100000(decimal price)
        {
            var ticket = new TicketRequest { Price = 1000, FlightNumber = "AFDET324" };
            _fixure.Validator.ShouldNotHaveValidationErrorFor(t => t.Price, ticket);
        }

        [Theory]
        [InlineData("ANG34")]
        [InlineData("678sBS97")]
        [InlineData("YD678DBS97")]
        public void Should_not_have_error_when_Number_Length_is_Greater_That_5_And_Less_Than_10(string number)
        {
            var ticket = new TicketRequest { Price = 1000, FlightNumber = "AFDET324" };
            _fixure.Validator.ShouldNotHaveValidationErrorFor(t => t.FlightNumber, ticket);
        }
    }
}
