using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Interfaces;

public interface IGradeRepository
{
    //CRUD 
    Task<IEnumerable<Grade>> GetAllAsync();
    Task<Grade?> GetByIdAsync(int enrollmentId); // Se usa InscripcionId
    Task AddAsync(Grade entity);
    void Update(Grade entity);
    void Delete(Grade entity);
    
    //Consultas específicas
    Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId);
    Task<decimal> GetAverageByCourseIdAsync(int courseId);
    
    //Persistencia
    Task<int> SaveChangesAsync();   
}