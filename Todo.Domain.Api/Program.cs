global using Microsoft.EntityFrameworkCore;
global using Todo.Domain.Api.Repositories;
global using Todo.Domain.Commands.Handlers;
global using Todo.Domain.Infra.Context;
global using Todo.Domain.Repositories;
global using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("Database"));
var connectionString = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<TodoContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Authority = "https://securetoken.google.com/todos-27c02";
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/todos-27c02",
            ValidateAudience = true,
            ValidAudience = "todos-27c02",
            ValidateLifetime = true
        };
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
                 endpoints.MapControllers());

app.Run();
