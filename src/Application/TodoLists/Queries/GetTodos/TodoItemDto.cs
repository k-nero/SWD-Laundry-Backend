﻿using AutoMapper;
using SWD_Laundry_Backend.Application.Common.Mappings;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.TodoLists.Queries.GetTodos;

public class TodoItemDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }

    public int Priority { get; init; }

    public string? Note { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TodoItem, TodoItemDto>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
    }
}
