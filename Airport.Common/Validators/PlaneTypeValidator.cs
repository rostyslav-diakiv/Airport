namespace Airport.Common.Validators
{
    using Airport.Common.Requests;

    using FluentValidation;

    public class PlaneTypeValidator : AbstractValidator<PlaneTypeRequest>
    {
        public PlaneTypeValidator()
        {
            RuleFor(x => x.MaximalCarryingCapacityKg).NotEmpty().Must(kg => kg > 999 && kg < 1000001).WithMessage("Please specify a valid Carrying Capacity in Kg. Min value: 1000, Max value: 1000000");
            RuleFor(x => x.MaximalNumberOfPlaces).NotEmpty().Must(p => p > 2 && p < 1000).WithMessage("Please specify a valid Number Of Places. Min value: 3, Max value: 1000");
            RuleFor(x => x.PlaneModel).NotEmpty().Length(2, 50).WithMessage("Please specify a valid Plane Model. Max length: 50, Min length: 3");
        }
    }
}
