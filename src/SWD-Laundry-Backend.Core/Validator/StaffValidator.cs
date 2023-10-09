using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
