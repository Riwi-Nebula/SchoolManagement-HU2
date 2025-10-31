using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infraestructure.Data;

namespace SchoolManagement.Infraestructure.Repositories;

public class SectionRepository : ISectionRepository
{
    private readonly AppDbContext _section;
    public SectionRepository(AppDbContext section)
    {
        _section = section;
    }

    public async Task<IEnumerable<Section>> GetByCourseAsync(int courseId) => await _section
        .Sections.Where(s => s.CourseId == courseId).ToListAsync();

    public async Task<Section> GetSectionByIdAsync(int id) => await _section.Sections
        .FirstOrDefaultAsync(s => s.Id == id);

    public async Task AddSectionAsync(Section section)
    {
        _section.Sections.Add(section);
        await _section.SaveChangesAsync();
    }

    public async Task UpdateSectionAsync(Section section)
    {
        _section.Sections.Update(section);
        await _section.SaveChangesAsync();
    }

    public async Task DeleteSectionAsync(int id)
    {
        var section = await _section.Sections.FindAsync(id);
        if (section != null)
            {
            _section.Sections.Remove(section);
            await _section.SaveChangesAsync();
            }
    }
}