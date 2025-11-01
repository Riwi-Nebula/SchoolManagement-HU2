namespace SchoolManagement.Domain.Entities;

public class Section
{
    public int Id { get; set; }
    
    //relacion con Course
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public string Day {get; set;}
    public string Hour { get; set; }
    public string Classroom { get; set; }
    public int MaxCapacity { get; set; }
}