using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Infraestructure.Repositories;

public class TeacherRepository : ITeacherRepository
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