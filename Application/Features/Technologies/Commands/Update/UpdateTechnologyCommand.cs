using Application.Features.ProgrammingLanguages.Dtos;
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

namespace Application.Features.SubTechnologies.Commands.Update
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class UpdateSubTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public UpdateSubTechnologyCommandHandler(ITechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedSubTechnology = _mapper.Map<Technology>(request);
                Technology updatedSubTechnology = await _subTechnologyRepository.UpdateAsync(mappedSubTechnology);

                UpdatedTechnologyDto updatedSubTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedSubTechnology);

                return updatedSubTechnologyDto;
            }
        }
    }
}
