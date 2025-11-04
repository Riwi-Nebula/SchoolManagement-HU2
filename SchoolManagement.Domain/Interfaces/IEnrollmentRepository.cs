using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Interfaces;

public interface IEnrollmentRepository
{
   Task<IEnumerable<Enrollment?>> GetAllAsync();
   Task AddAsync(Enrollment entity);
   void Delete(Enrollment entity);
   
   //Consultas
    Task<int> CountInSectionIdAsync(int sectionId);
    Task<bool> HasHoraryConflictAsync(int  studentId, int sectionId);
    Task<IEnumerable<Section>> GetSectionByStudentIdAsync(int studentId);
    Task<IEnumerable<Student>>  GetStudentsBySectionIdAsync(int sectionId);
    Task<Enrollment?> GetByIdsAsync(int studentId, int sectionId);
    Task<Enrollment?> GetByIdAsync(int id);
    Task<int> SaveChangesAsync(); 
   
}
