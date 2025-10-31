using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Interfaces;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllAsync(); // GetAll
    Task<Teacher?> GetByIdAsync(int id); // GetById
    Task AddAsync(Teacher teacher); // Add
    Task UpdateAsync(Teacher teacher); // Update
    Task DeleteAsync(Teacher teacher); // Delete
}