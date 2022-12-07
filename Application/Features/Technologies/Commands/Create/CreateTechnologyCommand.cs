using Application.Features.SubTechnologies.Dtos;
using Application.Services.Repositories;
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
    public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateSubTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly ITechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public CreateSubTechnologyCommandHandler(ITechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedSubTechnology = _mapper.Map<Technology>(request);
                Technology createSubTechnology = await _subTechnologyRepository.AddAsync(mappedSubTechnology);

                CreatedTechnologyDto createdSubTechnologyDto = _mapper.Map<CreatedTechnologyDto>(createSubTechnology);

                return createdSubTechnologyDto;
            }
        }

    }
}
