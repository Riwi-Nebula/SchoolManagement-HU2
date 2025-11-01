using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infraestructure.Data;
using SchoolManagement.Infraestructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// =======================================================
// 1. Configuración de la cadena de conexión a MySQL
// =======================================================

// Obtiene la cadena desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ⚡ Configura EF Core con autodetección de versión MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// =======================================================
// 2. Inyección de dependencias
// =======================================================

// Repositorios
//Ejemplo:
//builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
// Servicios de aplicación
//Ejemplo:
//builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<EnrollmentService>();
builder.Services.AddScoped<GradeService>();

// =======================================================
// 3. Controladores y Swagger
// =======================================================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "School Management API",
        Version = "v1",
        Description = "API para la gestión de estudiantes, cursos y registros académicos"
    });
});

// =======================================================
// 4. Construcción y pipeline
// =======================================================

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Management API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

