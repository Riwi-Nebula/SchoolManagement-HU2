using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _teacherRepository.GetAllAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID inválido.");
        
        var existing = await _teacherRepository.GetByIdAsync(id);
        if (existing == null)
            throw new InvalidOperationException("El profesor no existe.");

        return await _teacherRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Teacher teacher)
    {
        if (string.IsNullOrWhiteSpace(teacher.Name))
            throw new ArgumentException("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(teacher.LastName))
            throw new ArgumentException("El apellido es obligatorio");
        if (string.IsNullOrWhiteSpace(teacher.Specialization))
            throw new ArgumentException("La especialización es obligatoria.");
        
        await _teacherRepository.AddAsync(teacher);
    }

    public async Task UpdateAsync(Teacher teacher)
    {
        var existing = await _teacherRepository.GetByIdAsync(teacher.Id);
        if (existing == null)
            throw new InvalidOperationException("El profesor no existe.");

        await _teacherRepository.UpdateAsync(teacher);
    }

    public async Task DeleteAsync(Teacher teacher)
    {
        var existing = await _teacherRepository.GetByIdAsync(teacher.Id);
        if (existing == null)
            throw new InvalidOperationException("El estudiante no existe.");
        
        await _teacherRepository.DeleteAsync(teacher);
    }
}