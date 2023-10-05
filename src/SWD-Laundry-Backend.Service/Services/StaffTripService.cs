using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(IStaffTripService))]
public class StaffTripService : Base_Service.Service, IStaffTripService
{
    private readonly Expression<Func<Staff_Trip, object>>[]? items =
        {
            p => p.Staff,
            p => p.Building,
            p => p.TimeSchedule
        };

    private readonly IStaffTripRepository _repository;
    private readonly IMapper _mapper;

    public StaffTripService(IStaffTripRepository staffTripRepository, IMapper mapper)
    {
        _repository = staffTripRepository;
        _mapper = mapper;
    }

    public async Task<string> CreateAsync(StaffTripModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<Staff_Trip>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.DeleteAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return numberOfRows;
    }

    public async Task<ICollection<Staff_Trip>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(
            cancellationToken: cancellationToken,
            includes: items);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Staff_Trip?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var query = await _repository.GetAsync(
            c => c.Id == id,
            cancellationToken: cancellationToken,
            includes: items);

        var obj = await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return obj;
    }

    public async Task<int> UpdateAsync(string id, StaffTripModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.TripCollect, model.TripCollect)
            .SetProperty(x => x.TripType, model.TripType)
            .SetProperty(x => x.TimeScheduleID, model.TimeScheduleID)
            .SetProperty(x => x.BuildingID, model.BuildingID)
            .SetProperty(x => x.StaffID, model.StaffID)
            , cancellationToken);

        return numberOfRows;
    }
}