using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Repositories;
using QuanLiNhanSu.Repositories.Implements;
using QuanLiNhanSu.Services;
using QuanLiNhanSu.Services.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DBContext
builder.Services.AddDbContext<QuanLiNhansu1Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("QuanLiNhanSu")));

// Add CORS
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Add Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Life Cycle DI : AddSingleton(). AddTransient(), AddScope()

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
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
