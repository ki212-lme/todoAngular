using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.Data;
using WebApplication1.Data.Repository;
using WebApplication1.Data.Repository.RepositoryInterfaces;

var builder = WebApplication.CreateBuilder(args);


string connectionString =
        $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory()
       + @"\Data\Db\Tododb.mdf"}" + @";Integrated Security=True;";

builder.Services.AddDbContext<DBContext>(op => op.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITodoRepository, TodoRespository>();

builder.Services.AddCors(
    builder => {
        builder.AddPolicy("DefaultPolicy", 
            option=>option
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });

var app = builder.Build();

app.UseCors("DefaultPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();