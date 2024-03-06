using Application.Common.Interfaces;
using Application.CQRS.RubroCqrs.Commands.DeleteCommand;
using Application.CQRS.RubroCqrs.Commands.RubroCreateCommand;
using Application.CQRS.RubroCqrs.Commands.UpdatedCommand;
using Application.CQRS.RubroCqrs.Query;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace buen_sabor.api.Controllers;

[SwaggerResponse(200, "Success")]
[SwaggerResponse(404, "Not found")]
[SwaggerResponse(401, "Token required")]
[SwaggerResponse(500, "Internal error")]
public class RubroController : ApiController
{
    [HttpGet("Rubro/{id}")]
    [SwaggerOperation(Summary = "Obtiene un Rubro.")]
    public async Task<ActionResult> GetRubro(Guid id)
    {
        var query = new GetRubroQuery();
        query.AssignId(id);

        var res = await Mediator.Send(query);
        return Ok(res);
    }

    [HttpPost("Rubro")]
    [SwaggerOperation(Summary = "Crea un Rubro.")]
    public async Task<IResult> PostRubro([FromBody] CreateRubroCommand command, IValidator<CreateRubroCommand> validator)
    {
        var validation = validator.Validate(command);
        if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());

        var res = await Mediator.Send(command);
        return Results.Ok(res);
    }
    
    [HttpPut("Rubro/{id}")]
    [SwaggerOperation(Summary = "Actualiza un Rubro.")]
    public async Task<IResult> UpdateRubro([FromBody] UpdateRubroCommand command, Guid id, IValidator<UpdateRubroCommand> validator)
    {
        var validation = validator.Validate(command);
        if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());

        if (command.Id != id) return Results.BadRequest();
        command.AssignId(id);

        var res = await Mediator.Send(command);
        return Results.Ok(res);
    }
    
    [HttpDelete("Rubro/{id}")]
    [SwaggerOperation(Summary = "Deshabilita un Rubro.")]
    public async Task<IResult> DeleteRubro(Guid id)
    {
        var command = new DeleteRubroCommand();
        command.AssignId(id);

        var res = await Mediator.Send(command);
        return Results.Ok(res);
    }
}
