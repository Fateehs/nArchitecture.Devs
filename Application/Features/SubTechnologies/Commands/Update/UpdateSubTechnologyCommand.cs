using Application.Features.ProgrammingLanguages.Dtos;
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

namespace Application.Features.SubTechnologies.Commands.Update
{
    public class UpdateSubTechnologyCommand : IRequest<UpdatedSubTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class UpdateSubTechnologyCommandHandler : IRequestHandler<UpdateSubTechnologyCommand, UpdatedSubTechnologyDto>
        {
            private readonly ISubTechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public UpdateSubTechnologyCommandHandler(ISubTechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSubTechnologyDto> Handle(UpdateSubTechnologyCommand request, CancellationToken cancellationToken)
            {
                SubTechnology mappedSubTechnology = _mapper.Map<SubTechnology>(request);
                SubTechnology updatedSubTechnology = await _subTechnologyRepository.UpdateAsync(mappedSubTechnology);

                UpdatedSubTechnologyDto updatedSubTechnologyDto = _mapper.Map<UpdatedSubTechnologyDto>(updatedSubTechnology);

                return updatedSubTechnologyDto;
            }
        }
    }
}
