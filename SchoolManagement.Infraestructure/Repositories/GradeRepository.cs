using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infraestructure.Data;

namespace SchoolManagement.Infraestructure.Repositories;

public class GradeRepository : IGradeRepository
{
    private readonly AppDbContext _context;
    
    public GradeRepository(AppDbContext context)
    {
        _context = context;
    }
//CRUD
    public async Task<IEnumerable<Grade>> GetAllAsync() => await _context.Grades.ToListAsync();
    public async Task<Grade?> GetByIdAsync(int inscripcionId) => await _context.Grades.FindAsync(inscripcionId);
    public async Task AddAsync(Grade entity) => await _context.Grades.AddAsync(entity);
    public void Update(Grade entity) => _context.Grades.Update(entity);
    public void Delete(Grade entity) => _context.Grades.Remove(entity);
    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();


//Consulta Calificaciones por Estudiante
    public async Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId)
    {
        return await _context.Grades
            .Include(g => g.score)
            .Where(g => g.Enrollment.StudentId == studentId)
            .ToListAsync();
    }

    //Promedio de notas por curso
    public async Task<decimal> GetAverageByCourseIdAsync(int courseId)
    {
        var promedio = await _context.Grades
            .Include(g => g.Enrollment)
            .Include(g => g.Enrollment.Section)
            .Where(c => c.Enrollment.Section.CourseId == courseId) // Asumimos que Seccion tiene CursoId
            .AverageAsync(c => (decimal?)c.score); // Se usa (decimal?) para manejar el caso de no haber notas

        return promedio ?? 0m; // Devuelve 0 si no hay notas.
    }
}