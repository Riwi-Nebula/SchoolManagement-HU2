using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Interfaces;

public interface ISectionRepository
{
    Task<IEnumerable<Section>> GetByCourseAsync(int courseId);
    Task<Section> GetSectionByIdAsync(int id);
    Task AddSectionAsync(Section section);
    Task UpdateSectionAsync(Section section);
    Task DeleteSectionAsync(int id);
}