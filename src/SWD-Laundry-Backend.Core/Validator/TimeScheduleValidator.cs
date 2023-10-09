using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class TimeScheduleValidator : AbstractValidator<TimeScheduleModel>
{
    public TimeScheduleValidator()
    {
        RuleFor(x => x.StartTime)
            .Must((model, startTime) => startTime < model.EndTime)
            .WithMessage("StartTime must be earlier than EndTime.");

        RuleFor(x => x.DayOfWeek)
            .IsInEnum().WithMessage("Invalid DayOfWeek.");

        RuleFor(x => x.TimeFrame)
            .IsInEnum().WithMessage("Invalid TimeFrame.");
    }
}
