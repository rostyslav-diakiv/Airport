namespace Airport.Common.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class PlaneValidator : AbstractValidator<PlaneRequest>
    {
        public PlaneValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 50).WithMessage("Please specify a valid Name. Max length: 50, Min length: 3");
            RuleFor(x => x.LifeTime).NotEmpty().Must(BeAValidLifeTime).WithMessage("Please specify a valid Life Time. It has to be at least 1 day and maximum 50000 days");
            RuleFor(x => x.CreationDate).NotEmpty().Must(BeAValidCreationDate).WithMessage($"Please specify a valid Creation Date. Pilot have be born between {DateTime.UtcNow.AddYears(-50).ToShortDateString()} and {DateTime.UtcNow.ToShortDateString()}");
            RuleFor(x => x.PlaneTypeId).NotEmpty().WithMessage("Please specify a valid Plane Type Id. Plane Type with such Id doesn't exists");
        }

        private bool BeAValidLifeTime(TimeSpan time)
        {
            if (time < TimeSpan.FromDays(1) || time > TimeSpan.FromDays(50000))
                return false;

            return true;
        }

        private bool BeAValidCreationDate(DateTime date)
        {
            if (date > DateTime.UtcNow || date < DateTime.UtcNow.AddYears(-50))
                return false;

            return true;
        }
    }
}
