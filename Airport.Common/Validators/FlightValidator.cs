namespace Airport.Common.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class FlightValidator : AbstractValidator<FlightRequest>
    {
        public FlightValidator()
        {
            RuleFor(x => x.Number).NotEmpty().Must(n => n.Length >= 5 && n.Length <= 10).WithMessage("Please specify a valid Flight Number");
            RuleFor(x => x.DepartureTime).NotEmpty().Must(BeAValidTime).WithMessage("Please specify a valid Departure Time");
            RuleFor(x => x.DestinationArrivalTime).NotEmpty().Must(BeAValidTime).WithMessage("Please specify a valid Arrival Time");
            RuleFor(x => x.Destination).NotEmpty().Must(n => n.Length > 2 && n.Length < 50).WithMessage("Please specify a valid Destination Place");
            RuleFor(x => x.PointOfDeparture).NotEmpty().Must(n => n.Length > 2 && n.Length < 50).WithMessage("Please specify a valid Point Of Departure");
            RuleFor(x => x).NotEmpty().Must(x => x.Destination != x.PointOfDeparture && x.DestinationArrivalTime > x.DepartureTime.AddHours(3)).WithMessage("Please specify a valid Arrival Time or  Destination Place");
        }

        private bool BeAValidTime(DateTime date)
        {
            if (date < DateTime.UtcNow || date > DateTime.UtcNow.AddYears(2))
                return false;

            return true;
        }
    }
}
