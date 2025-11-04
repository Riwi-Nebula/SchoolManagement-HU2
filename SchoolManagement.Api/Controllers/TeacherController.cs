using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await _teacherService.GetAllAsync();
        return Ok(teachers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            return Ok(teacher);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(Teacher teacher)
    {
        try
        {
            await _teacherService.AddAsync(teacher);
            return Ok("Profesor agregado correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Teacher teacher)
    {
        try
        {
            await _teacherService.UpdateAsync(teacher);
            return Ok("Profesor actualizado correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            await _teacherService.DeleteAsync(teacher!);
            return Ok("Profesor eliminado correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}