using FluentValidation;
using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Application.Buildings.Commands.CreateBuilding;
public class CreateBuildingCommandValidator : AbstractValidator<CreateBuildingCommand>
{
    private readonly IApplicationDbContext _context;
    
    public CreateBuildingCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(v => v.Name).NotEmpty();
        RuleFor(v => v.Description).NotEmpty();
        RuleFor(v => v.Address).NotEmpty();
    }
}
