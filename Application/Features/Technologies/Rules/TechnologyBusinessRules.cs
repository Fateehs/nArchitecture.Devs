using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _subTechnologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository subTechnologyRepository)
        {
            _subTechnologyRepository = subTechnologyRepository;
        }

        public async Task SubTechnologyCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _subTechnologyRepository.GetListAsync(s => s.Name == name);
            if (result.Items.Any()) throw new BusinessException("Sub Technology name exists.");
        }

        public void SubTechnologyMustExistWhenRequested(Technology subTechnology)
        {
            if (subTechnology == null) throw new BusinessException("Requested sub technology does not exists.");
        }
    }
}
