using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllAsync(); // GetAll
    Task<Student?> GetByIdAsync(int id); // GetById
    Task AddAsync(Student student); // Add
    Task UpdateAsync(Student student); // Update
    Task DeleteAsync(Student student); // Delete
}