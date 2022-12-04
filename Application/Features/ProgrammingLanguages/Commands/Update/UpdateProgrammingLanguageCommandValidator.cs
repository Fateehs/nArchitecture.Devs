using Application.Features.ProgrammingLanguages.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.Update
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
        }
    }
}
