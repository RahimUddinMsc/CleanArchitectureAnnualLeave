using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendars.Commands.CreateCalendarItem
{
    public class CreateCalanderItemCommandValidator: AbstractValidator<CreateCalanderItemCommand>
    {
        public CreateCalanderItemCommandValidator()
        {
            RuleFor(v => v.Day).NotNull().NotEmpty().WithMessage("{PropertyName} value is required");
            RuleFor(v => v.Month).NotNull().NotEmpty().WithMessage("{PropertyName} value is required");
            RuleFor(v => v.Year).NotNull().NotEmpty().WithMessage("{PropertyName} value is required");            
            RuleFor(v => v.Minutes).NotNull().NotEmpty().WithMessage("{PropertyName} value is required");            
        }
    }
}
