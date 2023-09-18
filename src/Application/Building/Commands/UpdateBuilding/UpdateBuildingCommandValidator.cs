using FluentValidation;
using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Application.Building.Commands.UpdateBuilding;
public class UpdateBuildingCommandValidator : AbstractValidator<UpdateBuildingCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBuildingCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name);
        RuleFor(v => v.Address);
        RuleFor(v => v.Description);
    }
}
