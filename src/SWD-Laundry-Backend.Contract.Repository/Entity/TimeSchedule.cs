﻿using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Enum;



#nullable disable

public class TimeSchedule : BaseEntity
{ 
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    #region Special Attribute

    public DayOfWeek DayOfWeek { get; set; }
    public TimeFrame TimeFrame { get; set; }
    public List<Staff_Trip> Staff_Trip { get; set; }

    #endregion Special Attribute
}