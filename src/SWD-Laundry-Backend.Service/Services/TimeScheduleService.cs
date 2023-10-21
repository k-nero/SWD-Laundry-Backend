using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(ITimeScheduleService))]
public class TimeScheduleService : Base_Service.Service, ITimeScheduleService
{
    private readonly ITimeScheduleRepository _repository;
    private readonly IMapper _mapper;

    public TimeScheduleService(ITimeScheduleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<string> CreateAsync(TimeScheduleModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<TimeSchedule>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await _repository.DeleteAsync(x => x.Id == id,
            cancellationToken);
        return i;
    }

    public async Task<ICollection<TimeSchedule>> GetAllAsync(TimeScheduleQuery? query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<TimeSchedule?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken);
        return entity;
    }


    public async Task<PaginatedList<TimeSchedule>> GetPaginatedAsync(TimeScheduleQuery query, CancellationToken cancellationToken = default)

    {
        var list = await _repository
    .GetAsync(c => c.IsDelete == query.IsDeleted
    , cancellationToken: cancellationToken);

        var result = await list.PaginatedListAsync(query);
        return result;
    }

    public async Task<int> UpdateAsync(string id, TimeScheduleModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.StartTime, model.StartTime)
            .SetProperty(x => x.EndTime, model.EndTime)
            .SetProperty(x => x.DayOfWeek, model.DayOfWeek)
            .SetProperty(x => x.TimeFrame, model.TimeFrame)
            , cancellationToken);

        return numberOfRows;
    }
}