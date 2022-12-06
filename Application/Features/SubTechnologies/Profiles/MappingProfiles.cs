using Application.Features.SubTechnologies.Commands.Create;
using Application.Features.SubTechnologies.Commands.Delete;
using Application.Features.SubTechnologies.Commands.Update;
using Application.Features.SubTechnologies.Dtos;
using Application.Features.SubTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SubTechnology, CreateSubTechnologyCommand>().ReverseMap();
            CreateMap<SubTechnology, CreatedSubTechnologyDto>().ReverseMap();

            CreateMap<SubTechnology, UpdateSubTechnologyCommand>().ReverseMap();
            CreateMap<SubTechnology, UpdatedSubTechnologyDto>().ReverseMap();

            CreateMap<SubTechnology, DeleteSubTechnologyCommand>().ReverseMap();
            CreateMap<SubTechnology, DeletedSubTechnologyDto>().ReverseMap();

            CreateMap<SubTechnology, SubTechnologyListDto>().ReverseMap();
            CreateMap<IPaginate<SubTechnology>, SubTechnologyListModel>().ReverseMap();

            CreateMap<SubTechnology, SubTechnologyGetByIdDto>().ReverseMap();
        }
    }
}
