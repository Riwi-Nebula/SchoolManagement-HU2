using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.DTOs;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SectionController : ControllerBase
{
    private readonly SectionService _service;
    public SectionController(SectionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<SectionReadDto>> Create([FromBody] SectionCreateDto dto)
    {
        try
        {
            var section = new Section
            {
                CourseId = dto.CourseId,
                Day = dto.Day,
                Hour = dto.Hour,
                Classroom = dto.Classroom,
                MaxCapacity = dto.MaxCapacity
            };

            await _service.AddSectionAsync(section);

            var result = new SectionReadDto
            {
                Id = section.Id,
                CourseId = section.CourseId,
                Day = section.Day,
                Hour = section.Hour,
                Classroom = section.Classroom,
                MaxCapacity = section.MaxCapacity
            };

            return CreatedAtRoute("GetSectionById", new { id = section.Id }, result);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}", Name = "GetSectionById")]
    public async Task<ActionResult<SectionReadDto>> GetSectionByIdAsync(int id)
    {
        var section = await _service.GetSectionByIdAsync(id);
        if (section == null)
            return NotFound();

        var result = new SectionReadDto
        {
            Id = section.Id,
            CourseId = section.CourseId,
            Day = section.Day,
            Hour = section.Hour,
            Classroom = section.Classroom,
            MaxCapacity = section.MaxCapacity
        };

        return Ok(result);
    }

    [HttpGet("course/{courseId}")]
    public async Task<ActionResult<IEnumerable<Section>>> GetByCourseAsync(int courseId)
    {
        var sections = await _service.GetSectionsByCourseAsync(courseId);
        return Ok(sections);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSectionAsync(int id, [FromBody] SectionCreateDto dto)
    {
        var section = await _service.GetSectionByIdAsync(id);
        if (section == null)
            return NotFound(new { message = "Section not found" });

        section.CourseId = dto.CourseId;
        section.Day = dto.Day;
        section.Hour = dto.Hour;
        section.Classroom = dto.Classroom;
        section.MaxCapacity = dto.MaxCapacity;

        await _service.UpdateSectionAsync(section);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteSectionAsync(id);
        return NoContent();
    }
}