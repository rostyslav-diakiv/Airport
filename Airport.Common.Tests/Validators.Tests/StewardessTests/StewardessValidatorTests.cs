namespace Airport.Common.Tests.Validators.Tests.StewardessTests
{
    using Airport.Common.Requests;

    using FluentValidation.TestHelper;

    using Xunit;

    public class StewardessValidatorTests : IClassFixture<StewardessValidatorFixture>
    {
        private readonly StewardessValidatorFixture _fixure;

        public StewardessValidatorTests(StewardessValidatorFixture fixure)
        {
            _fixure = fixure;
        }

        [Theory]
        [InlineData("A")]
        public void Should_have_error_when_Price_length_is_Less_Than_5_And_Greater_That_10(string name)
        {
            var stewardess = new StewardessRequest() { Name = name };
            _fixure.Validator.ShouldHaveValidationErrorFor(t => t.Name, stewardess);
        }
    }
}
