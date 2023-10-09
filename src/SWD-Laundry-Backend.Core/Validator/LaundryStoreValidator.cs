using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class LaundryStoreValidator : AbstractValidator<LaundryStoreModel>
{
    public LaundryStoreValidator()
    {
        RuleFor(x => x.StoreName)
            .NotEmpty().WithMessage("StoreName is required.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.");

        RuleFor(x => x.StartTime)
            .NotNull().WithMessage("StartTime is required.");

        RuleFor(x => x.EndTime)
            .NotNull().WithMessage("EndTime is required.")
            .GreaterThan(x => x.StartTime)
            .WithMessage("EndTime must be greater than StartTime.");
    }
}
