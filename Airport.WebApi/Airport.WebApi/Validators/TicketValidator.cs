namespace Airport.WebApi.Validators
{
    using Airport.Common.Requests;

    using FluentValidation;

    public class TicketValidator : AbstractValidator<TicketRequest>
    {
        public TicketValidator()
        {
            RuleFor(x => x.Price).Must(p => p > 5 && p < 100000).WithMessage("Please specify a valid Price");
            RuleFor(x => x.FlightNumber).Must(n => n.Length > 5 && n.Length < 10).WithMessage("Please specify a valid Flight Number");
        }
    }
}
