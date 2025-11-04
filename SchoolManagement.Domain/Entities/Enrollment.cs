namespace SchoolManagement.Domain.Entities;

public class Enrollment
{
    public int Id { get; set; }
    
    public int StudentId { get; set; }
    public int SectionId { get; set; }
    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    
    public Student  Student { get; set; }
    public Section Section { get; set; }
    
    public Grade? Grade { get; set; }
}