namespace Airport.WebApi.Validators
{
    using Airport.Common.Requests;

    using FluentValidation;

    public class PlaneTypeValidator : AbstractValidator<PlaneTypeRequest>
    {
        public PlaneTypeValidator()
        {
            RuleFor(x => x.MaximalCarryingCapacityKg).Must(kg => kg > 1000 && kg < 1000000).WithMessage("Please specify a valid Carrying Capacity in Kg");
            RuleFor(x => x.MaximalNumberOfPlaces).Must(p => p > 2 && p < 1000).WithMessage("Please specify a valid Number Of Places");
            RuleFor(x => x.PlaneModel).Length(2, 50).WithMessage("Please specify a valid Plane Model");
        }
    }
}
