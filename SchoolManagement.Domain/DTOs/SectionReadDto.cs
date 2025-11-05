namespace SchoolManagement.Domain.DTOs;

public class SectionReadDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Day { get; set; }
    public string Hour { get; set; }
    public string Classroom { get; set; }
    public int MaxCapacity { get; set; }
}