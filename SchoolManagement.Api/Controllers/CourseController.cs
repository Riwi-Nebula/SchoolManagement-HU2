using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.DTOs;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly CourseService _service;
    public CourseController(CourseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseReadDto>>> GetCoursesAsync()
    {
        var courses = await _service.GetAllCoursesAsync();

        var result = courses.Select(c => new CourseReadDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        });

        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetCourseById")]
    public async Task<ActionResult<CourseReadDto>> GetCourseByIdAsync(int id)
    {
        var course = await _service.GetCourseByIdAsync(id);
        if (course == null)
            return NotFound(new { message = "Course not found" });

        return Ok(new CourseReadDto
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description
        });
    }

    [HttpPost]
    public async Task<ActionResult<CourseReadDto>> AddCourseAsync([FromBody] CourseCreateDto dto)
    {
        var course = new Course
        {
            Name = dto.Name,
            Description = dto.Description
        };

        await _service.AddCourseAsync(course);

        var result = new CourseReadDto
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description
        };

        return CreatedAtRoute("GetCourseById", new { id = course.Id }, result);


    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourseAsync(int id,  [FromBody] CourseCreateDto dto)
    {
        var course = await _service.GetCourseByIdAsync(id);
        if (course == null)
            return NotFound(new { message = "Course not found" });

        course.Name = dto.Name;
        course.Description = dto.Description;

        await _service.UpdateCourseAsync(course);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourseAsync(int id)
    {
        await _service.DeleteCourseAsync(id);
        return NoContent();
    }
}