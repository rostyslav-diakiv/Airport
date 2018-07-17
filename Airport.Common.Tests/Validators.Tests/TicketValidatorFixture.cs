namespace Airport.Common.Tests.Validators.Tests
{
    using Airport.Common.Validators;

    public class TicketValidatorFixture
    {
        public TicketValidator Validator { get; }

        public TicketValidatorFixture() // Calls constructor for every test in class
        {
            // Setup and Seed Database
            Validator = new TicketValidator();
        }
    }
}
