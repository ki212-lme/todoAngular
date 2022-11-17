namespace WebApplication1.Data.Repository.RepositoryInterfaces;

public interface ITodoRepository
{
    public Task<Todo> CreateTodo(Todo model);
    public Task<Todo> UpdateTodo(Todo model);
    public Task<Todo?> GetById(int id);
    public Task<Todo> DeleteTodo(int id);
    public Task<List<Todo>> GetAllTodos();
}