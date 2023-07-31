namespace LMSSchool.Models;

internal class Subject
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<byte> Grades { get; set; }

}
