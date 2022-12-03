﻿using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }


    }
}
