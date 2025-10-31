using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services;

public class TeacherService : ITeacherService
{
    public Task<IEnumerable<Teacher>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Teacher?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Teacher teacher)
    {
        throw new NotImplementedException();
    }
}