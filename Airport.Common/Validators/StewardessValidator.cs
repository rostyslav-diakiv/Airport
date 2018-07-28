﻿namespace Airport.Common.Validators
{
    using System;

    using Airport.Common.Requests;

    using FluentValidation;

    public class StewardessValidator : AbstractValidator<StewardessRequest>
    {
        public StewardessValidator()
        {
            RuleFor(x => x.DateOfBirth).NotEmpty().Must(BeAValidDateOfBirth).WithMessage("Please specify a valid Date Of Birth");
            RuleFor(x => x.Name).NotEmpty().Length(2, 50).WithMessage("Please specify a valid Name");
            RuleFor(x => x.FamilyName).NotEmpty().Length(2, 50).WithMessage("Please specify a valid Family Name");
        }

        private bool BeAValidDateOfBirth(DateTime date)
        {
            if (date > DateTime.UtcNow.AddYears(-18) || date < DateTime.UtcNow.AddYears(-110))
                return false;

            return true;
        }
    }
}
