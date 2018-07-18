namespace Airport.Common.Tests.Validators.Tests.TicketTests
{
    using Airport.Common.Validators;

    public class TicketValidatorFixture
    {
        public TicketValidator Validator { get; }

        public TicketValidatorFixture() 
        {
            Validator = new TicketValidator();
        }
    }
}
