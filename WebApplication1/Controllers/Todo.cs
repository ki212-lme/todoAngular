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
    public async Task<List<Todo>> f() => await TodoRepository.GetAllTodos();
}