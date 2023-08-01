using LMSSchool.Services.Classes;
using LMSSchool.Services.Intefaces;
using System.Collections;

namespace LMSSchool.Models;

internal class Pupil:IEnumerable
{
    private readonly IPupilCRUDService _pupilCRUDService;
    public Pupil()
    {
        _pupilCRUDService = new PupilCRUDService();
        Console.WriteLine($"Name:");
        Name = Console.ReadLine();
        Console.WriteLine("\tSubjects:\n\t");
        Subjects = new();
        while (true)
        {
            Subjects.Add(new Subject());
            Console.WriteLine("Continue add SUBJECT? 'Y' or 'N'");
            if (Console.ReadLine() == "N") break;
        }

        _pupilCRUDService.Create(this);
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<Subject> Subjects { get; set; }

    public IEnumerator GetEnumerator()
    {
        return Subjects.GetEnumerator();
    }

    public override string ToString()
    {
        return $"\nName student: {Name}\nID: {Id}";
    }


}
