namespace SchoolManagement.Domain.Entities;

public class Grade
{
    public int id { get; set; }
    public int IncriptionId { get; set; }
    public decimal score  { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    
    public Enrollment Enrollment { get; set; }
    
}