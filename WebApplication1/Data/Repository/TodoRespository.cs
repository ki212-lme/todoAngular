using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Repository.RepositoryInterfaces;

namespace WebApplication1.Data.Repository;

public class TodoRespository:ITodoRepository
{
    private DBContext DbContext => new DBContext();

    public TodoRespository()
    {
    }

    public async Task<Todo?> CreateTodo(Todo? model)
    {
        await using (DbContext)
        {
            try
            {
                await DbContext.Todos.AddAsync(model);
                await  DbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }

    public async Task<Todo> UpdateTodo(Todo model)
    {
        await using (DbContext)
        {
            try
            {
                var todo = await DbContext.Todos.FirstOrDefaultAsync(x=>x.Id==model.Id);
                if (todo!=null)
                {
                    todo = model;
                }
                await DbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }

    public async Task<Todo?> GetById(int id)
    {
        await using (DbContext)
        {
            return await DbContext.Todos.FirstOrDefaultAsync(x=>x.Id==id);
        }
    }

    public async Task<Todo> DeleteTodo(int id)
    {
        await using (DbContext)
        {
            var todo = await GetById(id);
            if (todo == null)
            {
                throw new Exception("todo with this id wasn't fin");
            }

            DbContext.Todos.Remove(new Todo(){Id = id});
            await DbContext.SaveChangesAsync();
            return todo;
        }
    }

    public async Task<List<Todo>> GetAllTodos()
    {
        await using (DbContext)
        {
            return  await DbContext.Todos.ToListAsync();
        }
    }
}