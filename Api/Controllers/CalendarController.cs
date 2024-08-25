using Application.Features.Calendars.Commands;
using Application.Features.Calendars.Commands.EditCalendarItem;
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

        [HttpPost(Name = "AddCalendarItem")]
        public async Task<ActionResult<CalendarListVM>> AddCalendarItem([FromBody] CreateCalanderItemCommand createCalendarItemCommand)
        {
            var id = await _mediator.Send(createCalendarItemCommand);
            return Ok(id);
        }


        [HttpPut(Name = "EditCalendarItem")]
        public async Task<ActionResult<CalendarListVM>> EditCalendarItem([FromBody] EditCalendarItemCommand editCalendarItemCommand)
        {
            var id = await _mediator.Send(editCalendarItemCommand);
            return Ok(id);
        }
    }
}
