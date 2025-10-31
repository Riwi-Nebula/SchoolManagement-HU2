using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Interfaces;

public interface ITeacherService
{
    Task<IEnumerable<Teacher>> GetAllAsync(); // GetAll
    Task<Teacher?> GetByIdAsync(int id); // GetById
    Task AddAsync(Teacher teacher); // Add
    Task UpdateAsync(Teacher teacher); // Update
    Task DeleteAsync(Teacher teacher); // Delete
}