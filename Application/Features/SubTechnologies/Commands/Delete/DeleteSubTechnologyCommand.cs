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

namespace Application.Features.SubTechnologies.Commands.Delete
{
    public class DeleteSubTechnologyCommand : IRequest<DeletedSubTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteSubTechnologyCommandHandler : IRequestHandler<DeleteSubTechnologyCommand, DeletedSubTechnologyDto>
        {
            private readonly ISubTechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public DeleteSubTechnologyCommandHandler(ISubTechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSubTechnologyDto> Handle(DeleteSubTechnologyCommand request, CancellationToken cancellationToken)
            {
                SubTechnology mappedSubTechnology = _mapper.Map<SubTechnology>(request);
                SubTechnology deletedSubTechnology = await _subTechnologyRepository.DeleteAsync(mappedSubTechnology);

                DeletedSubTechnologyDto deletedSubTechnologyDto = _mapper.Map<DeletedSubTechnologyDto>(deletedSubTechnology);

                return deletedSubTechnologyDto;
            }
        }
    }
}
