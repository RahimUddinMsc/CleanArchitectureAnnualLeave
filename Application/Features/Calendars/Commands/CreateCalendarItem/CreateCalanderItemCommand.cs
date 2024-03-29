﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendars.Commands
{
    public class CreateCalanderItemCommand : IRequest<Guid>
    {
        public int Day {get; set;}
        public int Month {get; set;}
        public int Year { get; set;}           
        public int Minutes { get; set;}
    }
}
