using LMSSchool.Services.Classes;

namespace LMSSchool.Models;

internal class Subject
{
    private readonly SubjectCRUDService _subjectCRUDService;
    public Subject()
    {
        _subjectCRUDService = new SubjectCRUDService();
        Console.WriteLine($"Name Sub:");
        Name = Console.ReadLine();
        Console.WriteLine("\tGrades('6' for stop):\n");
        byte grades=0;
        Grades = new();
        while (true)
        {
            grades=byte.Parse(Console.ReadLine());
            if (grades == 6) break;
            Grades.Add(grades);
        }
        _subjectCRUDService.Create(this);

    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<byte> Grades { get; set; }
    public override string ToString()
    {
        string cw = $"Name Subject: {Name} \nID: {Id}\nGrades: ";
        foreach (byte grade in Grades) {
            cw+=(grade.ToString()+" ");
        }
        return cw;
    }

}
