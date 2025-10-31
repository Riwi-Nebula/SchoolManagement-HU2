using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class SectionService
{
    private readonly ISectionRepository _repository;
    public SectionService(ISectionRepository repository)
    {
        _repository = repository;
    }

    public async Task AddSectionAsync(Section section)
    {
        var existingSections = await _repository.GetByCourseAsync(section.CourseId);
        bool overlaps = existingSections.Any(s => s.Day == section.Day && s.Hour == section.Hour);
        if (overlaps)
            throw new InvalidOperationException("There is already a section in this schedule");
        
        await _repository.AddSectionAsync(section);
    }

    public async Task<Section?> GetSectionByIdAsync(int id)
    {
        return await _repository.GetSectionByIdAsync(id);
    }

    public async Task<IEnumerable<Section>> GetSectionsByCourseAsync(int courseId)
    {
        return await _repository.GetByCourseAsync(courseId);
    }

    public async Task UpdateSectionAsync(Section section)
    {
        var existingSections = await _repository.GetByCourseAsync(section.CourseId);
        
        bool overlaps = existingSections.Any(s => s.Id != section.Id && s.Day == section.Day && s.Hour == section.Hour);
        if (overlaps)
            throw new InvalidOperationException("There is already a section with this schedule");
        await _repository.UpdateSectionAsync(section);
    }

    public async Task DeleteSectionAsync(int id)
    {
        await _repository.DeleteSectionAsync(id);
    }
}