using AnnualLeave.Models;
using Application.Features.Calendars.Commands;
using Application.Features.Calendars.Queries.GetCalendarList;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Calendar,CalendarListVM>().ReverseMap();
            CreateMap<Calendar,CreateCalanderItemCommand>().ReverseMap(); 
        }
    }
}
