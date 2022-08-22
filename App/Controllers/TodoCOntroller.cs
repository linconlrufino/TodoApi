using Domain.Commands;
using Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
        )
    {
        command.User = "tolstoi";
        return (GenericCommandResult)handler.Handle(command);
    }

}
