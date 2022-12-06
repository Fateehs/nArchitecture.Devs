using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Commands.Update
{
    public class UpdateSubTechnologyCommandValidator : AbstractValidator<UpdateSubTechnologyCommand>
    {
        public UpdateSubTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
        }
    }
}
