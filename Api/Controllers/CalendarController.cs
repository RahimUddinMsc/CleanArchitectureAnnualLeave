using Application.Features.Calendars.Queries.GetCalendarList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("Api/Calendar")]
    public class CalendarController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CalendarController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<CalendarListVM>> GetCalendarList ()
        {
            var data = await _mediator.Send(new GetCalendarListQuery());

            return Ok(data);
        }
    }
}
