using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repository.RepositoryInterfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : Controller
{
    private ITodoRepository TodoRepository { get; set; }

    public TodoController(ITodoRepository todoRepository)
    {
        TodoRepository = todoRepository;
    }

    [HttpGet]
    public async Task<List<Todo>> GetAllTodos() => await TodoRepository.GetAllTodosAsync();

    [HttpPost]
    [Route("create")]
    public async Task<Todo> CreateTodo([FromBody] Todo todo)
    {
        return await TodoRepository.CreateTodoAsync(todo);
    }

    [HttpPost]
    [Route("update")]
    public async Task<Todo> Update([FromBody] Todo todo)
    {
        return await TodoRepository.UpdateTodoAsync(todo);
    }

}