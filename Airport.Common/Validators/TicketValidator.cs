namespace Airport.Common.Validators
{
    using Airport.Common.Requests;

    using FluentValidation;

    public class TicketValidator : AbstractValidator<TicketRequest>
    {
        public TicketValidator()
        {
            RuleFor(x => x.Price).NotEmpty().InclusiveBetween(5, 100000).WithMessage("Please specify a valid Price");
            RuleFor(x => x.FlightNumber).NotEmpty().Must(n => n.Length >= 5 && n.Length <= 10).WithMessage("Please specify a valid Flight Number");
        }
    }
}
