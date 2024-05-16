using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Services;
using QuanLiNhanSu2.Services.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Add DBContext
builder.Services.AddDbContext<QuanLiNhanSuContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("QuanLiNhanSu")));

// Add Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Life Cycle DI : AddSingleton(). AddTransient(), AddScope()
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
