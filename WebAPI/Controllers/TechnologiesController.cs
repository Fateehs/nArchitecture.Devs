using Application.Features.ProgrammingLanguages.Commands.Create;
using Application.Features.ProgrammingLanguages.Commands.Delete;
using Application.Features.ProgrammingLanguages.Commands.Update;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.SubTechnologies.Commands.Create;
using Application.Features.SubTechnologies.Commands.Delete;
using Application.Features.SubTechnologies.Commands.Update;
using Application.Features.SubTechnologies.Dtos;
using Application.Features.SubTechnologies.Models;
using Application.Features.SubTechnologies.Queries.GetByIdSubTechnology;
using Application.Features.SubTechnologies.Queries.GetListSubTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class TechnologiesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createSubTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createSubTechnologyCommand);
            return Created("", result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateSubTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateSubTechnologyCommand);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteSubTechnologyCommand)
        {
            DeletedTechnologyDto result = await Mediator.Send(deleteSubTechnologyCommand);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListSubTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListSubTechnologyQuery);

            return Ok(result);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdSubTechnologyQuery)
        {
            TechnologyGetByIdDto subTechnologyGetByIdDto = await Mediator.Send(getByIdSubTechnologyQuery);

            return Ok(subTechnologyGetByIdDto);
        }
    }
}
