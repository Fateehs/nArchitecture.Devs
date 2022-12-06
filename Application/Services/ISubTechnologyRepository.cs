﻿using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISubTechnologyRepository : IAsyncRepository<SubTechnology>, IRepository<SubTechnology>
    {
    }
}
