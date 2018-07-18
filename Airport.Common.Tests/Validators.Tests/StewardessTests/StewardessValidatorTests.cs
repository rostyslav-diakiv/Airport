namespace Airport.Common.Tests.Validators.Tests.StewardessTests
{
    using System;
    using System.Collections.Generic;

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
        [InlineData("")]
        [InlineData("A")]
        [InlineData("1234567890214325423rtertertertwqerterqgdrsfgrffgtrrtg64256354624592438529602456747653749657543762475690275762765904275960745")]
        public void Should_have_error_when_name_length_is_Less_Than_2_And_Greater_That_50(string name)
        {
            var stewardess = new StewardessRequest() { Name = name };
            _fixure.Validator.ShouldHaveValidationErrorFor(t => t.Name, stewardess);
        }

        [Theory]
        [MemberData("GetYoungDateGenerator", MemberType = typeof(TestDataGenerator))]
        public void Should_have_error_when_name_Date_is_Less_Than_18_Yers_Ago(DateTime date)
        {
            var stewardess = new StewardessRequest() { DateOfBirth = date };
            _fixure.Validator.ShouldHaveValidationErrorFor(t => t.DateOfBirth, stewardess);
        }

        [Theory]
        [MemberData("GetOldDateGenerator", MemberType = typeof(TestDataGenerator))]
        public void Should_have_error_when_name_Date_is_More_Than_18_Yers_Ago(DateTime date)
        {
            var stewardess = new StewardessRequest() { DateOfBirth = date };
            _fixure.Validator.ShouldNotHaveValidationErrorFor(t => t.DateOfBirth, stewardess);
        }

        [Theory]
        [InlineData("AAA")]
        [InlineData("SBEYD678DBS97")]
        [InlineData("ASDW")]
        public void Should_not_have_error_when_name_length_Between_2_And_50(string name)
        {
            var stewardess = new StewardessRequest() { Name = name };
            _fixure.Validator.ShouldNotHaveValidationErrorFor(t => t.Name, stewardess);
        }
    }
    public class TestDataGenerator
    {
        public static IEnumerable<object[]> GetYoungDateGenerator()
        {
            yield return new object[] { new DateTime(2005, 12, 12) };
            yield return new object[] { new DateTime(2002, 12, 12) };
        }

        public static IEnumerable<object[]> GetOldDateGenerator()
        {
            yield return new object[] { new DateTime(1995, 12, 12) };
            yield return new object[] { new DateTime(1999, 12, 12) };
        }
    }
}
