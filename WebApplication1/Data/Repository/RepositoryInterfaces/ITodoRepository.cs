namespace WebApplication1.Data.Repository.RepositoryInterfaces;

public interface ITodoRepository
{
    public Task<Todo> CreateTodoAsync(Todo model);
    public Task<Todo> UpdateTodoAsync(Todo model);
    public Task<Todo?> GetByIdAsync(int id);
    public Task<Todo> DeleteTodo(int id);
    public Task<List<Todo>> GetAllTodosAsync();
}