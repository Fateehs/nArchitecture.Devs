using Application.Features.SubTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Queries.GetByIdSubTechnology
{
    public class GetByIdTechnologyQuery : IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdSubTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
        {
            private readonly ITechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public GetByIdSubTechnologyQueryHandler(ITechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                Technology subTechnology = await _subTechnologyRepository.GetAsync
                    (b => b.Id == request.Id,
                    include: s => s.Include(p => p.ProgrammingLanguage));

                TechnologyGetByIdDto subTechnologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(subTechnology);

                return subTechnologyGetByIdDto;
            }
        }
    }
}
