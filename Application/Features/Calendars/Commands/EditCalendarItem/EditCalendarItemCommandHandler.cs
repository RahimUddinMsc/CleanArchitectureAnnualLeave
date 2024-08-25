using AnnualLeave.Models;
using Application.Contracts.Database;
using MediatR;

namespace Application.Features.Calendars.Commands.EditCalendarItem;
internal sealed class EditCalendarItemCommandHandler(IAsyncRepository<Calendar> _repo) : IRequestHandler<EditCalendarItemCommand, Guid>
{

    public async Task<Guid> Handle(EditCalendarItemCommand request, CancellationToken cancellationToken)
    {
        var calendarItem = await _repo.GetByIdAsync(request.CalendarId);

        if (calendarItem == null)
            throw new ArgumentNullException(nameof(calendarItem));

        calendarItem.AvailableMinutes = request.Minutes;

        await _repo.UpdateAsync(calendarItem);

        return calendarItem.Id;
    }
}

