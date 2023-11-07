using Microsoft.EntityFrameworkCore;
using Task_Manager_Web_API.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// 


// Database realated
var connString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connString));




builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();