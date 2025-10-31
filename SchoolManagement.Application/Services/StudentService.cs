using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services;

public class StudentService : IStudentService
{
    public Task<IEnumerable<Student>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Student?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Student student)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Student student)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Student student)
    {
        throw new NotImplementedException();
    }
}