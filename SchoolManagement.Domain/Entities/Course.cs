namespace SchoolManagement.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    //Relacion 1-N (profesor puede tener muchos cursos)
    
    //public int TeacherId { get; set; }      ==>Descomentar para unirlo a Professor
    //public Teacher Teacher { get; set; }   ==>Descomentar para unirlo a Professor
    
    //Relacion 1-N (curso puede tener muchas secciones)
    public ICollection<Section>? Sections { get; set; }
}