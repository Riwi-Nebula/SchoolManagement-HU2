//using SchoolManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infraestructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    //Metodo protegido para definir pruebas adicionales o configuraciones
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Ejemplo:
        // modelBuilder.Entity<Student>()
        //     .HasIndex(s => s.Email)
        //     .IsUnique();W
        //Esto crea un indice unico sobre el campo de del email en la tabla de students
        base.OnModelCreating(modelBuilder);
    }
    
    //Aca agregan las entidades con las que se van a crear las tablas
    public DbSet<Enrollment> Enrollments { get; set; } = null!;
    public DbSet<Grade> Grades { get; set; } = null!;
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Section> Sections { get; set; }
}