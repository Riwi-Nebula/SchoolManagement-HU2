using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetAllAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var student = await _studentService.GetByIdAsync(id);
            return Ok(student);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(Student student)
    {
        try
        {
            await _studentService.AddAsync(student);
            return Ok("Estudiante agregado correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Student student)
    {
        try
        {
            await _studentService.UpdateAsync(student);
            return Ok("Estudiante actualizado correctamente.");
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
            var student = await _studentService.GetByIdAsync(id);
            await _studentService.DeleteAsync(student!);
            return Ok("Estudiante eliminado correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}