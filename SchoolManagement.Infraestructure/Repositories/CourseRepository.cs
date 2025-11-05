using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infraestructure.Data;

namespace SchoolManagement.Infraestructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _course;
    public CourseRepository(AppDbContext course)
    {
        _course = course;
    }
    
    public async Task<IEnumerable<Course>> GetAllCoursesAsync() => await _course.Courses
        .Include(c => c.Sections).ToListAsync();
        //.Include(c => c.Teacher).ToListAsync();  Descomentar para unirlo a Professor (se sustituye la linea de arriba por esta)
    

    public async Task<Course> GetCourseByIdAsync(int id) => await _course.Courses
        .Include(c => c.Sections).FirstOrDefaultAsync(c => c.Id == id);
    

    public async Task AddCourseAsync(Course course)
    {
        _course.Courses.Add(course);
        await _course.SaveChangesAsync();
    }

    public async Task UpdateCourseAsync(Course course)
    {
        _course.Courses.Update(course);
        await _course.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(int id)
    {
        var course = await _course.Courses.FindAsync(id);
        if (course != null)
            {
            _course.Courses.Remove(course);
            await _course.SaveChangesAsync();
            }
    }
}