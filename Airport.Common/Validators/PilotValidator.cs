namespace Airport.Common.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class PilotValidator : AbstractValidator<PilotRequest>
    {
        public PilotValidator()
        {
            RuleFor(x => x.Experience).NotEmpty().Must(BeAValidExperience).WithMessage("Please specify a valid Experience. It has to be at least 1 day and maximum 50000 days");
            RuleFor(x => x.DateOfBirth).NotEmpty().Must(BeAValidDateOfBirth).WithMessage($"Please specify a valid Date Of Birth. Pilot have be born between {DateTime.UtcNow.AddYears(-110).ToShortDateString()} and {DateTime.UtcNow.AddYears(-18).ToShortDateString()}");
            RuleFor(x => x.Name).NotEmpty().Length(2, 51).WithMessage("Please specify a valid Name. Max length: 50, Min length: 3");
            RuleFor(x => x.FamilyName).NotEmpty().Length(2, 51).WithMessage("Please specify a valid Family Name. Max length: 50, Min length: 3");
        }

        private bool BeAValidExperience(TimeSpan time)
        {
            if (time < TimeSpan.FromDays(1) || time > TimeSpan.FromDays(50000))
                return false;

            return true;
        }

        private bool BeAValidDateOfBirth(DateTime date)
        {
            if (date > DateTime.UtcNow.AddYears(-18) || date < DateTime.UtcNow.AddYears(-110))
                return false;

            return true;
        }
    }
}
