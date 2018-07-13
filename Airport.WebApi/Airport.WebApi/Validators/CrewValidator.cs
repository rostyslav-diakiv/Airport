namespace Airport.WebApi.Validators
{
    using System.Linq;

    using Airport.Common.Requests;

    using FluentValidation;

    public class CrewValidator : AbstractValidator<CrewRequest>
    {
        public CrewValidator()
        {
            RuleFor(x => x.PilotId).NotEmpty().WithMessage("Please specify a Pilot");
            RuleFor(x => x.StewardessesIds).Must(ints => ints.Any()).WithMessage("Please specify at least 1 Stewardess");
        }
    }
}
