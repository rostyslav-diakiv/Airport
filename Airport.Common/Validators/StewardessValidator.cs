namespace Airport.Common.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class StewardessValidator : AbstractValidator<StewardessRequest>
    {
        public StewardessValidator()
        {
            RuleFor(x => x.DateOfBirth).NotEmpty().Must(BeAValidDateOfBirth).WithMessage($"Please specify a valid Date Of Birth. Stewardess have be born between {DateTime.UtcNow.AddYears(-110).ToShortDateString()} and {DateTime.UtcNow.AddYears(-18).ToShortDateString()}");
            RuleFor(x => x.Name).NotEmpty().Length(2, 51).WithMessage("Please specify a valid Name. Max length: 50, Min length: 3");
            RuleFor(x => x.FamilyName).NotEmpty().Length(2, 51).WithMessage("Please specify a valid Family Name. Max length: 50, Min length: 3");
        }

        private bool BeAValidDateOfBirth(DateTime date)
        {
            if (date > DateTime.UtcNow.AddYears(-18) || date < DateTime.UtcNow.AddYears(-110))
                return false;

            return true;
        }
    }
}
