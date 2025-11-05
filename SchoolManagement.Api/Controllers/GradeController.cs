
using Microsoft.AspNetCore.Mvc;

using SchoolManagement.Application.Services;

// Simple DTO to receive the grade value
public class GradeDto 
{ 
    public decimal Value { get; set; } // Renamed Nota to Value
}

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{
    private readonly GradeService _gradeService;

    public GradesController(GradeService gradeService) => _gradeService = gradeService;

    // PUT: api/Grades/1 (Register or update grade by EnrollmentId)
    [HttpPut("{enrollmentId}")]
    public async Task<IActionResult> Upsert(int enrollmentId, [FromBody] GradeDto dto)
    {
        try
        {
            // Renamed CalificacionService to GradeService, Calificacion to Grade, Nota to Value
            var grade = await _gradeService.UpsertGradeAsync(enrollmentId, dto.Value);
            return Ok(grade);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
    
    // GET: api/Grades/Student/1 (Query a student's grades)
    [HttpGet("Student/{studentId}")]
    public async Task<IActionResult> GetByStudentId(int studentId) => 
        Ok(await _gradeService.GetGradesByStudentIdAsync(studentId));

    // GET: api/Grades/Average/Course/1 (Query course average)
    [HttpGet("Average/Course/{courseId}")]
    public async Task<IActionResult> GetAverageByCourseId(int courseId) => 
        Ok(new { Average = await _gradeService.GetAverageByCourseIdAsync(courseId) });
        
    // GET: api/Grades/1 (Query a grade by EnrollmentId)
    [HttpGet("{enrollmentId}")]
    public async Task<IActionResult> Get(int enrollmentId)
    {
        var grade = await _gradeService.GetByIdAsync(enrollmentId);
        if (grade == null) return NotFound();
        return Ok(grade);
    }
    
    // DELETE: api/Grades/1 (Delete a grade by EnrollmentId)
    [HttpDelete("{enrollmentId}")]
    public async Task<IActionResult> Delete(int enrollmentId)
    {
        var success = await _gradeService.DeleteAsync(enrollmentId);
        if (!success) return NotFound();
        return NoContent();
    }
}