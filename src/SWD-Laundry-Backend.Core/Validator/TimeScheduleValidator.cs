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
