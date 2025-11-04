using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Application.Services;


namespace SchoolManagement.Api.Controllers;

[ApiController]
[Route("api/Enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly EnrollmentService _enrollmentService;

    public EnrollmentController(EnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Post([FromBody] Enrollment enrollment)
    {
        try
        {
            var newEnrollment = await _enrollmentService.RegisterEnrollmentAsync(enrollment.StudentId, enrollment.SectionId);
            return CreatedAtAction(nameof(GetEnrolledStudents), new { sectionId = enrollment.SectionId }, newEnrollment);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
    // GET: api/Enrollments
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _enrollmentService.GetAllEnrollmentsAsync());
    
    // GET: api/Enrollments/Student/1 (Query sections for a student)
    [HttpGet("Student/{studentId}")]
    public async Task<IActionResult> GetEnrolledSections(int studentId) => 
        Ok(await _enrollmentService.GetEnrolledSectionsAsync(studentId));

    // GET: api/Enrollments/Section/1 (Query students in a section)
    [HttpGet("Section/{sectionId}")]
    public async Task<IActionResult> GetEnrolledStudents(int sectionId) =>
        Ok(await _enrollmentService.GetEnrolledStudentsAsync(sectionId));

    // DELETE: api/Enrollments?studentId=1&sectionId=10 (Using Query Params for the composite key)
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int studentId, [FromQuery] int sectionId)
    {
        var success = await _enrollmentService.DeleteEnrollmentAsync(studentId, sectionId);
        if (!success) return NotFound();
        return NoContent();
    }
    
    
}