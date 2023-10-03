using AutoMapper;
using Invedia.Core.ObjUtils;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;

using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(ITimeScheduleService))]
internal class TimeScheduleService : Base_Service.Service, ITimeScheduleService
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
        var numberOfRows = await _repository.DeleteAsync(x => x.Id == id, cancellationToken);
        return numberOfRows;
    }

    public async Task<ICollection<TimeSchedule>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var timescheduleList = await _repository.GetAsync( cancellationToken: cancellationToken);
        return await timescheduleList.ToListAsync(cancellationToken); 
    }

    public async Task<TimeSchedule?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var query = await _repository.GetAsync(c => c.Id == id, cancellationToken);
        var obj = await query.FirstOrDefaultAsync();
        return obj;
    }

    public async Task<int> UpdateAsync(string id, TimeScheduleModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.StartTime, model.StartTime)
            .SetProperty(x => x.EndTime, model.EndTime)
            .SetProperty(x => x.DayOfWeek, model.DayOfWeek)
            .SetProperty(x => x.TimeFrame, model.TimeFrame)
            ,cancellationToken);

        return numberOfRows;
    }
}