using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SWD_Laundry_Backend.Core.Enum;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class StaffTripValidator : AbstractValidator<StaffTripModel>
{
    public StaffTripValidator()
    {
        RuleFor(x => x.TripCollect)
            .GreaterThanOrEqualTo(0).WithMessage("TripCollect cannot be negative.");

        RuleFor(x => x.BuildingID)
            .NotEmpty().WithMessage("BuildingID is required when applicable.");

        RuleFor(x => x.TimeScheduleID)
            .NotEmpty().WithMessage("TimeScheduleID is required when applicable.");

        RuleFor(x => x.StaffID)
            .NotEmpty().WithMessage("StaffID is required when applicable.");

        RuleFor(x => x.TripType)
            .IsInEnum().WithMessage("Invalid TripType.");
    }
}
