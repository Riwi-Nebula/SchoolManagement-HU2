using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infraestructure.Data;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Infraestructure.Repositories;

public class EnrollmentRepository: IEnrollmentRepository
{
    private readonly AppDbContext _context;
    
    public EnrollmentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // CRUD Básico
    public async Task<IEnumerable<Enrollment?>> GetAllAsync() => await _context.Enrollments.ToListAsync();
    public async Task AddAsync(Enrollment entity) => await _context.Enrollments.AddAsync(entity);
    public void Delete(Enrollment entity) => _context.Enrollments.Remove(entity);
    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    public async Task<Enrollment?> GetByIdAsync(int id)
    {
        return await _context.Enrollments.FindAsync(id); 
    }

   // Obtener por IDs compuestos
        public async Task<Enrollment?> GetByIdsAsync(int studentId, int sectionId)
        {
            return await _context.Enrollments.FindAsync(studentId, sectionId);
        }

        //Consultas
        public async Task<int> CountInSectionIdAsync(int sectionId) 
            => await _context.Enrollments.CountAsync(i => i.SectionId == sectionId);

        public async Task<bool> HasHoraryConflictAsync(int studentId, int newSectionId)
        {
            
            var newSection = await _context.Set<Section>().FindAsync(newSectionId);
            if (newSection == null) return false;

            var registeredSections = await _context.Enrollments
                .Where(i => i.StudentId == studentId)
                .Select(i => i.Section)
                .ToListAsync();

            // Lógica de solapamiento
            return registeredSections.Any(s => 
                // 1. Mismo Día
                s.Day == newSection.Day && 
    
                // 2. Misma Hora de Inicio (NO permite que dos clases empiecen a la misma hora el mismo día)
                s.Hour == newSection.Hour
            );
        }
        
        public async Task<IEnumerable<Section>> GetSectionByStudentIdAsync(int studentId)
        {
            return await _context.Enrollments
                .Where(i => i.StudentId == studentId)
                .Select(i => i.Section)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsBySectionIdAsync(int sectionId)
        {
            return await _context.Enrollments
                .Where(i => i.SectionId == sectionId)
                .Select(i => i.Student)
                .ToListAsync();
        }

   
}