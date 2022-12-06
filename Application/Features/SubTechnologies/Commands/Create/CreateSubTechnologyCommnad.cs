using Application.Features.SubTechnologies.Dtos;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Commands.Create
{
    public class CreateSubTechnologyCommand : IRequest<CreatedSubTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateSubTechnologyCommandHandler : IRequestHandler<CreateSubTechnologyCommand, CreatedSubTechnologyDto>
        {
            private readonly ISubTechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public CreateSubTechnologyCommandHandler(ISubTechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSubTechnologyDto> Handle(CreateSubTechnologyCommand request, CancellationToken cancellationToken)
            {
                SubTechnology mappedSubTechnology = _mapper.Map<SubTechnology>(request);
                SubTechnology createSubTechnology = await _subTechnologyRepository.AddAsync(mappedSubTechnology);

                CreatedSubTechnologyDto createdSubTechnologyDto = _mapper.Map<CreatedSubTechnologyDto>(createSubTechnology);

                return createdSubTechnologyDto;
            }
        }

    }
}
