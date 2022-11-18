using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Repository.RepositoryInterfaces;

namespace WebApplication1.Data.Repository;

public class TodoRespository:ITodoRepository
{
    private DBContext DbContext { get; set; }

    public TodoRespository(DBContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Todo> CreateTodoAsync(Todo model)
    {
        await using (DbContext)
        {
            try
            { 
                DbContext.Todos.Add(model);
                await  DbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }

    public async Task<Todo> UpdateTodoAsync(Todo model)
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

    public async Task<Todo?> GetByIdAsync(int id)
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
            var todo = await GetByIdAsync(id);
            if (todo == null)
            {
                throw new Exception("todo with this id wasn't fin");
            }

            DbContext.Todos.Remove(new Todo(){Id = id});
            await DbContext.SaveChangesAsync();
            return todo;
        }
    }

    public async Task<List<Todo>> GetAllTodosAsync()
    {
        await using (DbContext)
        {
            return  await DbContext.Todos.FromSql($"SELECT * FROM Todos ORDER BY case when DateComplete is null then 1 else 0 end,  DateComplete asc").ToListAsync();
        }
    }
}