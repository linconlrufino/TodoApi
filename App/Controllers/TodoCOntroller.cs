using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetAll("tolstoi");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetAllDone("tolstoi");
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetAllUndone("tolstoi");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("tolstoi", DateTime.Now.Date, true);
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetInactiveForToday(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("tolstoi", DateTime.Now.Date, false);
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
    [FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("tolstoi", DateTime.Now.Date.AddDays(1), true);
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
   [FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("tolstoi", DateTime.Now.Date.AddDays(1), false);
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
        )
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody] UpdateTodoCommand command,
        [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone(
        [FromBody] MarkTodoAsDoneCommand command,
        [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone(
        [FromBody] MarkTodoAsUndoneCommand command,
        [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }
}
