namespace SchoolManagement.Domain.DTOs;

public class SectionCreateDto
{
    public int CourseId { get; set; }  // Solo referenciamos el curso
    public string Day { get; set; }
    public string Hour { get; set; }
    public string Classroom { get; set; }
    public int MaxCapacity { get; set; }
}