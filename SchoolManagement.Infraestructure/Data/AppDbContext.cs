//using SchoolManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infraestructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Course>  Courses { get; set; }
    public DbSet<Section>  Sections { get; set; }
    
    
    //Metodo protegido para definir pruebas adicionales o configuraciones
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Ejemplo:
        // modelBuilder.Entity<Student>()
        //     .HasIndex(s => s.Email)
        //     .IsUnique();
        //Esto crea un indice unico sobre el campo de del email en la tabla de students
        base.OnModelCreating(modelBuilder);
    }
    
    //Aca agregan las entidades con las que se van a crear las tablas
}