using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendars.Queries.GetCalendarList
{
    public class GetCalendarListQuery : IRequest<List<CalendarListVM>>
    {
    }
}
