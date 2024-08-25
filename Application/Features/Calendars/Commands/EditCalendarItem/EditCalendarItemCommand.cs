using MediatR;

namespace Application.Features.Calendars.Commands.EditCalendarItem;

public record EditCalendarItemCommand(Guid CalendarId, int Minutes) : IRequest<Guid>;


