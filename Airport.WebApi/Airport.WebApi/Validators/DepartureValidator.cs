namespace Airport.WebApi.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class DepartureValidator : AbstractValidator<DepartureRequest>
    {
        public DepartureValidator()
        {
            RuleFor(x => x.CrewId).NotEmpty().WithMessage("Please specify a valid Crew Id");
            RuleFor(x => x.PlaneId).NotEmpty().WithMessage("Please specify a valid Plane Id");
            RuleFor(x => x.FlightNumber).Must(n => n.Length > 5 && n.Length < 10).WithMessage("Please specify a valid Flight Number");
            RuleFor(x => x.DepartureTime).Must(BeAValidTime).WithMessage("Please specify a valid Departure Time");
        }

        private bool BeAValidTime(DateTime date)
        {
            if (date < DateTime.UtcNow || date > DateTime.UtcNow.AddYears(2))
                return false;

            return true;
        }
    }
}
