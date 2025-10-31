using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infraestructure.Data;

namespace SchoolManagement.Infraestructure.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _dbContext;
    public TeacherRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _dbContext.Teachers.ToListAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _dbContext.Teachers.FindAsync(id);
    }

    public async Task AddAsync(Teacher teacher)
    {
        _dbContext.Teachers.Add(teacher);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Teacher teacher)
    {
        _dbContext.Teachers.Update(teacher);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Teacher teacher)
    {
        _dbContext.Teachers.Remove(teacher);
        await _dbContext.SaveChangesAsync();
    }
}