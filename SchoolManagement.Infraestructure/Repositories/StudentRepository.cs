using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infraestructure.Data;

namespace SchoolManagement.Infraestructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _dbContext;
    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _dbContext.Students.FindAsync(id);
    }

    public async Task AddAsync(Student student)
    {
        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _dbContext.Students.Update(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Student student)
    {
        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();
    }
}