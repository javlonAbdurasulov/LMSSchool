using LMSSchool.Models;
using LMSSchool.Services.Intefaces;

namespace LMSSchool.Services.Classes;

internal class SubjectCRUDService : ISubjectCRUDService
{
    private List<Subject> _subjects = new List<Subject>();
    public void Create(Subject obj)
    {
        _subjects.Add(obj);
    }

    public void Delete(Guid id)
    {
        var removedSubject = _subjects.FirstOrDefault(p => p.Id.Equals(id));
        if (removedSubject != null)
        {
            _subjects.Remove(removedSubject);
        }
        else
        {
            throw new Exception($"Id= {id} fan topilmadi!");
        }
    }

    public IEnumerable<Subject> GetAll()
    {
        return _subjects;
    }

    public Subject GetById(Guid id)
    {
        var SelectedSubject = _subjects.FirstOrDefault(p => p.Id.Equals(id));
        if (SelectedSubject == null) throw new Exception($"Id= {id} fan topilmadi!");
        return SelectedSubject;
    }

    public void Update(Subject obj)
    {
        int index = _subjects.FindIndex(x => x.Id.Equals(obj.Id));
        _subjects[index] = obj;
    }
}
