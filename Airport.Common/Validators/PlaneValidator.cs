namespace Airport.Common.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class PlaneValidator : AbstractValidator<PlaneRequest>
    {
        public PlaneValidator()
        {
            RuleFor(x => x.Name).Length(2, 50).WithMessage("Please specify a valid Name");
            RuleFor(x => x.LifeTime).Must(BeAValidLifeTime).WithMessage("Please specify a valid Life Time");
            RuleFor(x => x.CreationDate).Must(BeAValidCreationDate).WithMessage("Please specify a valid Creation Date");
            RuleFor(x => x.PlaneTypeId).NotEmpty().WithMessage("Please specify a valid Plane Type Id");
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
