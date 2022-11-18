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
    public async Task<Todo> CreateTodo([FromBody] Todo todo)
    {
        return await TodoRepository.CreateTodoAsync(todo);
    }

    public async Task<Todo> ChangeCompleteState([FromBody] Todo todo)
    {
        var todoModel = await TodoRepository.GetByIdAsync(todo.Id);
        if (todoModel != null)
        {
            todoModel.IsCompleted = todo.IsCompleted;
            await TodoRepository.UpdateTodoAsync(todoModel);
            return todoModel;
        }

        throw new Exception("error to change state");
    }
}