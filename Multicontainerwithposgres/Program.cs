using Microsoft.EntityFrameworkCore;
using Multicontainerwithposgres.Data;
using Multicontainerwithposgres.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var myPostgresConnection = builder.Configuration.GetConnectionString("Myposgressdb");

builder.Services.AddDbContext<TeacherDbcontext>(c => c.UseNpgsql(myPostgresConnection));

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

app.UseAuthorization();

app.MapControllers();
app.CreateDbIfNotExists();
app.Run();
