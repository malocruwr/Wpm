using Microsoft.EntityFrameworkCore;
using Wpm.Management.Api.Infraestructure;
using Wpm.Management.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ManagementDbContext>(option => {
    option.UseSqlite("Data Source=Wpm.db");
});
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddScoped<ManagementApplicationService>();
var app = builder.Build();
app.EnsureDbIsCreated();

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
