using Application.Features.SubTechnologies.Dtos;
using Application.Services;
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
    public class GetByIdSubTechnologyQuery : IRequest<SubTechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdSubTechnologyQueryHandler : IRequestHandler<GetByIdSubTechnologyQuery, SubTechnologyGetByIdDto>
        {
            private readonly ISubTechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public GetByIdSubTechnologyQueryHandler(ISubTechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<SubTechnologyGetByIdDto> Handle(GetByIdSubTechnologyQuery request, CancellationToken cancellationToken)
            {
                SubTechnology subTechnology = await _subTechnologyRepository.GetAsync
                    (b => b.Id == request.Id,
                    include: s => s.Include(p => p.ProgrammingLanguage));

                SubTechnologyGetByIdDto subTechnologyGetByIdDto = _mapper.Map<SubTechnologyGetByIdDto>(subTechnology);

                return subTechnologyGetByIdDto;
            }
        }
    }
}
