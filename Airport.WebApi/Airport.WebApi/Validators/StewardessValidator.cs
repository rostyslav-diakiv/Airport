namespace Airport.WebApi.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class StewardessValidator : AbstractValidator<StewardessRequest>
    {
        public StewardessValidator()
        {
            RuleFor(x => x.DateOfBirth).Must(BeAValidDateOfBirth).WithMessage("Please specify a valid Date Of Birth");
            RuleFor(x => x.Name).Length(2, 50).WithMessage("Please specify a valid Name");
            RuleFor(x => x.FamilyName).Length(2, 50).WithMessage("Please specify a valid Family Name");
        }

        private bool BeAValidDateOfBirth(DateTime date)
        {
            if (date > DateTime.UtcNow.AddYears(-18) || date < DateTime.UtcNow.AddYears(-110))
                return false;

            return true;
        }
    }
}
