using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class StaffValidator : AbstractValidator<StaffModel>
{
    public StaffValidator()
    {
        RuleFor(x => x.ApplicationUserId).NotEmpty().WithMessage("ApplicationUserId is required.");
    }
}
