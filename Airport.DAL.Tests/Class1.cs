namespace Airport.DAL.Tests
{
    using System;

    using Airport.Common.Requests;
    using Airport.Common.Validators;

    using FluentValidation.TestHelper;

    using Xunit;

    public class Class1 : IDisposable
    {
        private TicketValidator validator;

        public Class1() // Calls constructor for every test in class
        {
            validator = new TicketValidator();
        }

        [Fact]
        public void Should_have_error_when_FlightNumber_is_wer()
        {
            var ticket = new TicketRequest { Price = 15, FlightNumber = "wer"};
            validator.ShouldHaveValidationErrorFor(t => t.FlightNumber, ticket);
        }

        [Fact]
        public void Should_not_have_error_when_Price_is_15()
        {
            var ticket = new TicketRequest { Price = 15, FlightNumber = "AFDET324" };
            validator.ShouldNotHaveValidationErrorFor(t => t.Price, ticket);
        }


        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                validator = null;
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
