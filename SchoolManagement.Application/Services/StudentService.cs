using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID inválido.");
        
        var existing = await _studentRepository.GetByIdAsync(id);
        if (existing == null)
            throw new InvalidOperationException("El estudiante no existe.");

        return await _studentRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Student student)
    {
        if (string.IsNullOrWhiteSpace(student.Name))
            throw new ArgumentException("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(student.LastName))
            throw new ArgumentException("El apellido es obligatorio");
        if (string.IsNullOrWhiteSpace(student.Email))
            throw new ArgumentException("El email es obligatorio.");

        await _studentRepository.AddAsync(student);
    }

    public async Task UpdateAsync(Student student)
    {
        var existing = await _studentRepository.GetByIdAsync(student.Id);
        if (existing == null)
            throw new InvalidOperationException("El estudiante no existe.");

        await _studentRepository.UpdateAsync(student);
    }

    public async Task DeleteAsync(Student student)
    {
        var existing = await _studentRepository.GetByIdAsync(student.Id);
        if (existing == null)
            throw new InvalidOperationException("El estudiante no existe.");
        
        await _studentRepository.DeleteAsync(student);
    }
}