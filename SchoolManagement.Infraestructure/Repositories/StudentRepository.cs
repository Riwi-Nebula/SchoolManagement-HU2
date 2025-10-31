using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Infraestructure.Repositories;

public class StudentRepository : IStudentRepository
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