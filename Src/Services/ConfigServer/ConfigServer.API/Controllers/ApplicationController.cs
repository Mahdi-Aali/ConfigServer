using AutoMapper;
using ConfigServer.API.Exceptions;
using ConfigServer.Application.Command.ApplicationCommands;
using ConfigServer.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConfigServer.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private IMapper _mapper;
    private IMediator _mediator;

    public ApplicationController(IMapper mapper, IMediator mediator) => (_mapper, _mediator) = (mapper, mediator);

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IReadOnlyCollection<string>))]
    public async Task<IActionResult> AddNewApplication([FromBody] CreateApplicationDTO createApplicationDTO)
    {
        if (ModelState.IsValid)
        {
            var cmd = _mapper.Map<CreateNewApplicationCommand>(createApplicationDTO);
            var response = await _mediator.Send(cmd);
            if (response.Result)
            {
                return Ok();
            }
            ModelState.AddModelError("All", response.ErrorMessage!);
        }

        return BadRequest(GetErrorMessagesFromModelState(ModelState));
    }

    private IReadOnlyCollection<string> GetErrorMessagesFromModelState(ModelStateDictionary modelState)
    {
        ApiExceptions apiExceptions = new();
        foreach(var item in modelState.Where(ms => ms.Value.Errors.Count() > 0))
        {
            foreach(var error in item.Value.Errors)
            {
                apiExceptions.AddErrorMessage(error.ErrorMessage);
            }
        }

        return apiExceptions.Errors;
    }
}
