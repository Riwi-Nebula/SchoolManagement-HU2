using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;

public class GradeService
{
    private readonly IGradeRepository _gradeRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;


    public GradeService(
        IGradeRepository gradeRepository,
        IEnrollmentRepository enrollmentRepository)
    {
        _gradeRepository = gradeRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public async Task<Grade> UpsertGradeAsync(int enrollmentId, decimal score)
    {
        if (score < 0 || score > 100)
        {
            throw new Exception("Error: La calificación debe estar entre 0 y 100.");
        }

        var existingGrade = await _gradeRepository.GetByIdAsync(enrollmentId);

        if (existingGrade != null)
        {
            existingGrade.score = score;
            _gradeRepository.Update(existingGrade);
            await _gradeRepository.SaveChangesAsync();
            return existingGrade;
        }
        else
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(enrollmentId); 

            if (enrollment == null)
            {
                throw new Exception("Error: No se encontró la inscripción para calificar.");
            }

            var newGrade = new Grade
            {
                IncriptionId = enrollmentId,
                score = score,
                RegistrationDate = DateTime.UtcNow
            };

            await _gradeRepository.AddAsync(newGrade);
            await _gradeRepository.SaveChangesAsync();
            return newGrade;
        }
    }
    
    public async Task<Grade?> GetByIdAsync(int enrollmentId)
    {
        return await _gradeRepository.GetByIdAsync(enrollmentId);
    }
    
    public async Task<bool> DeleteAsync(int enrollmentId)
    {
        var grade = await _gradeRepository.GetByIdAsync(enrollmentId);
        if (grade == null) return false;

        _gradeRepository.Delete(grade);
        await _gradeRepository.SaveChangesAsync();
        return true;
    }
    
    public async Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId)
    {
        return await _gradeRepository.GetGradesByStudentIdAsync(studentId);
    }

    public async Task<decimal> GetAverageByCourseIdAsync(int courseId)
    {
        return await _gradeRepository.GetAverageByCourseIdAsync(courseId);
    }
}