using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class BuildingValidator : AbstractValidator<BuildingModel>
{
    public BuildingValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
        //RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
    }
}
