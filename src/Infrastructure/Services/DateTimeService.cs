﻿using Application.Abstractions.Common;

namespace Infrastructure.Services;
public class DateTimeService :IDateTime
{
    public DateTime Now =>DateTime.Now;
}
