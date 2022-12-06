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
    public class SubTechnologiesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateSubTechnologyCommand createSubTechnologyCommand)
        {
            CreatedSubTechnologyDto result = await Mediator.Send(createSubTechnologyCommand);
            return Created("", result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSubTechnologyCommand updateSubTechnologyCommand)
        {
            UpdatedSubTechnologyDto result = await Mediator.Send(updateSubTechnologyCommand);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSubTechnologyCommand deleteSubTechnologyCommand)
        {
            DeletedSubTechnologyDto result = await Mediator.Send(deleteSubTechnologyCommand);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSubTechnologyQuery getListSubTechnologyQuery = new() { PageRequest = pageRequest };
            SubTechnologyListModel result = await Mediator.Send(getListSubTechnologyQuery);

            return Ok(result);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSubTechnologyQuery getByIdSubTechnologyQuery)
        {
            SubTechnologyGetByIdDto subTechnologyGetByIdDto = await Mediator.Send(getByIdSubTechnologyQuery);

            return Ok(subTechnologyGetByIdDto);
        }
    }
}
