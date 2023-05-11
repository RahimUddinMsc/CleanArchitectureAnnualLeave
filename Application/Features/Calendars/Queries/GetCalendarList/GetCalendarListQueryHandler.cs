using AnnualLeave.Models;
using Application.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendars.Queries.GetCalendarList
{
    public class GetCalendarListQueryHandler : IRequestHandler<GetCalendarListQuery, List<CalendarListVM>>
    {
        private readonly IAsyncRepository<Calendar> _calendarRepo;
        private readonly IMapper _mapper;

        public GetCalendarListQueryHandler(IMapper mapper, IAsyncRepository<Calendar> calendarRepo)
        {
            _mapper = mapper;
            _calendarRepo = calendarRepo;
        }

        public async Task<List<CalendarListVM>> Handle(GetCalendarListQuery request, CancellationToken cancellationToken)
        {
            var allItems = await _calendarRepo.ListAllAsync();
            return _mapper.Map<List<CalendarListVM>>(allItems); 
        }
    }
}
