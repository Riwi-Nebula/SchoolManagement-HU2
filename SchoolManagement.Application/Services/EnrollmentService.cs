using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class EnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly ISectionRepository _sectionRepository;
    private readonly IStudentRepository _studentRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository, ISectionRepository sectionRepository,
        IStudentRepository studentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
        _sectionRepository = sectionRepository;
        _studentRepository = studentRepository;
    }

//
    public async Task<Enrollment> RegisterEnrollmentAsync(int studentId, int sectionId)
    {
        // 1. Validar existencia de entidades (Se usa el repositorio de Estudiante/Seccion)
        var student = await _studentRepository.GetByIdAsync(studentId);
        var section = await _sectionRepository.GetSectionByIdAsync(sectionId);

        if (student == null || section == null)
        {
            throw new Exception("Estudiante o Sección no encontrados.");
        }

        // 2.Cupo lleno
        var AlreadyEnrolled = await _enrollmentRepository.CountInSectionIdAsync(sectionId);
        if (AlreadyEnrolled >= section.MaxCapacity)
        {
            throw new Exception("Error: El cupo máximo de la sección ha sido alcanzado.");
        }

        // 3. Conflicto de horario
        var hasConflict = await _enrollmentRepository.HasHoraryConflictAsync(studentId, sectionId);
        if (hasConflict)
        {
            throw new Exception("Error: Conflicto de horario con una sección ya inscrita.");
        }

        // Crear Inscripción
        var enrollment = new Enrollment { StudentId = studentId, SectionId = sectionId };
        await _enrollmentRepository.AddAsync(enrollment);
        await _enrollmentRepository.SaveChangesAsync();
        return enrollment;
    }

    public async Task<bool> DeleteEnrollmentAsync(int studentId, int sectionId)
    {
        var enrollment = await _enrollmentRepository.GetByIdsAsync(studentId, sectionId);

        if (enrollment == null) return false;

        _enrollmentRepository.Delete(enrollment);
        await _enrollmentRepository.SaveChangesAsync();

        return true;
    }


    public async Task<object?> GetAllEnrollmentsAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task<IEnumerable<Section>> GetEnrolledSectionsAsync(int studentId)
    {
        // Llama al repositorio para obtener la lista
        return await _enrollmentRepository.GetSectionByStudentIdAsync(studentId);
    }
    
    // El controlador espera que devuelva una lista de Estudiantes
    public async Task<IEnumerable<Student>> GetEnrolledStudentsAsync(int sectionId)
    {
        // Llama al repositorio para obtener la lista
        return await _enrollmentRepository.GetStudentsBySectionIdAsync(sectionId);
    }

}