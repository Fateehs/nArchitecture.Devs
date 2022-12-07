using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.SubTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Queries.GetListSubTechnology
{
    public class GetListTechnologyQuery : IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSubTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
        {
            private readonly ITechnologyRepository _subTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListSubTechnologyQueryHandler(ITechnologyRepository subTechnologyRepository, IMapper mapper)
            {
                _subTechnologyRepository = subTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> subTechnologies = await _subTechnologyRepository.GetListAsync
                    (include: m => m.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                TechnologyListModel mappedSubTechnologies = _mapper.Map<TechnologyListModel>(subTechnologies);

                return mappedSubTechnologies;
            }
        }
    }
}
