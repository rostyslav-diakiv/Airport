namespace Airport.Common.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class DepartureValidator : AbstractValidator<DepartureRequest>
    {
        public DepartureValidator()
        {
            RuleFor(x => x.CrewId).NotEmpty().WithMessage("Please specify a valid Crew Id. Crew with such Id doesn't exists");
            RuleFor(x => x.PlaneId).NotEmpty().WithMessage("Please specify a valid Plane Id. Plane with such Id doesn't exists");
            RuleFor(x => x.FlightNumber).NotEmpty().Must(n => n.Length >= 5 && n.Length <= 10).WithMessage("Please specify a valid Flight Number. Flight with such number doesn't exists");
            RuleFor(x => x.DepartureTime).NotEmpty().Must(BeAValidTime).WithMessage($"Please specify a valid Departure Time. Max Date: {DateTime.UtcNow.AddDays(-1).ToShortDateString()}, Max Date: {DateTime.UtcNow.AddYears(2).ToShortDateString()}");
        }

        private bool BeAValidTime(DateTime date)
        {
            if (date < DateTime.UtcNow.AddDays(-1) || date > DateTime.UtcNow.AddYears(2))
                return false;

            return true;
        }
    }
}
