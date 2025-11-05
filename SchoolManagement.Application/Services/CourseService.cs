using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class CourseService
{
    private readonly ICourseRepository _repository;

    public CourseService(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync() => await _repository.GetAllCoursesAsync();
    
    public async Task<Course?> GetCourseByIdAsync(int id) => await _repository.GetCourseByIdAsync(id);
    
    public async Task AddCourseAsync(Course course) => await _repository.AddCourseAsync(course);
    
    public async Task UpdateCourseAsync(Course course) => await _repository.UpdateCourseAsync(course);
    
    public async Task DeleteCourseAsync(int id) => await _repository.DeleteCourseAsync(id);
    
}