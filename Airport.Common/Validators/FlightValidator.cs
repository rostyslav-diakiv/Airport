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
            RuleFor(x => x.DepartureTime).NotEmpty().Must(BeAValidTime).WithMessage($"Please specify a valid Departure Time. Max Date: {DateTime.UtcNow.ToShortDateString()}, Max Date: {DateTime.UtcNow.AddYears(2).ToShortDateString()}");
            RuleFor(x => x.DestinationArrivalTime).NotEmpty().Must(BeAValidTime).WithMessage($"Please specify a valid Arrival Time. Max Date: {DateTime.UtcNow.ToShortDateString()}, Max Date: {DateTime.UtcNow.AddYears(2).ToShortDateString()}");
            RuleFor(x => x.Destination).NotEmpty().Must(n => n.Length > 2 && n.Length < 51).WithMessage("Please specify a valid Destination Place. Max length: 50, Min length: 3");
            RuleFor(x => x.PointOfDeparture).NotEmpty().Must(n => n.Length > 2 && n.Length < 50).WithMessage("Please specify a valid Point Of Departure. Max length: 50, Min length: 3");
            RuleFor(x => x).NotEmpty().Must(x => x.Destination != x.PointOfDeparture).WithMessage("Please specify a valid Data. You specified same Destination and Point Of Departure");
        }

        private bool BeAValidTime(DateTime date)
        {
            if (date < DateTime.UtcNow || date > DateTime.UtcNow.AddYears(2))
                return false;

            return true;
        }
    }
}
