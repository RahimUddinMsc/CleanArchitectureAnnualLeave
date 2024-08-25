using AnnualLeave.Models;
using Application.Contracts.Database;
using Application.Exceptions;
using Application.Features.Calendars.Commands.CreateCalendarItem;
using AutoMapper;
using MediatR;


namespace Application.Features.Calendars.Commands
{
    public class CreateCalanderItemCommandHandler : IRequestHandler<CreateCalanderItemCommand, Guid>
    {
        private readonly IAsyncRepository<Calendar> _repo;
        private readonly IMapper _mapper;

        public CreateCalanderItemCommandHandler(IMapper mapper, IAsyncRepository<Calendar> repo)
        {
            _mapper = mapper;
            _repo = repo;   
        }

        public async Task<Guid> Handle(CreateCalanderItemCommand request, CancellationToken cancellationToken)
        {
            var newCalendarItem = _mapper.Map<Calendar>(request);          
            var validator = new CreateCalanderItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
           

            await _repo.AddAsync(newCalendarItem);

            return newCalendarItem.Id;
        }
    }
}
