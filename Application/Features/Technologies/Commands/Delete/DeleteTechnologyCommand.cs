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

namespace Application.Features.SubTechnologies.Commands.Delete
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteSubTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public DeleteSubTechnologyCommandHandler(ITechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedSubTechnology = _mapper.Map<Technology>(request);
                Technology deletedSubTechnology = await _subTechnologyRepository.DeleteAsync(mappedSubTechnology);

                DeletedTechnologyDto deletedSubTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedSubTechnology);

                return deletedSubTechnologyDto;
            }
        }
    }
}
