using LMSSchool.Models;
using LMSSchool.Services.Intefaces;

namespace LMSSchool.Services.Classes
{
    internal class PupilCRUDService : IPupilCRUDService
    {
        
        private List<Pupil> _pupils = new();
        //{
        //    new Pupil() { Name="John",Subjects={ new Subject() { Name="Maths",Grades = { 5,4,3} }, new Subject() { Name = "Science", Grades = { 3, 4, 5 } } } },
        //    new Pupil() { Name="Jane",Subjects={ new Subject() { Name="Science",Grades = { 3,4,5} }, new Subject() { Name = "History", Grades = { 5, 5, 5 } } } },
        //    new Pupil() { Name="Jack",Subjects={ new Subject() { Name="History",Grades = { 2,3,4} }, new Subject() { Name = "Science", Grades = { 3, 4, 5 } }, } }
        //};

        public Dictionary<string, double> AvaregeGrade(IEnumerable<Pupil> pupils)
        {
            Dictionary<string,double> avaregeGrade = new();
            foreach (var pupil in pupils)
            {
                foreach (var item in pupil.Subjects)
                {
                    var avarage = item.Grades.Average(x=>x);
                    avaregeGrade.Add(pupil.Name+" "+item.Name+" => ", avarage);
                }
            }
            return avaregeGrade;
        }

        public Dictionary<string, IEnumerable<byte>> CountOfFiveGradesForEachSubject(IEnumerable<Pupil> pupils)
        {
            throw new NotImplementedException();
        }

        public void Create(Pupil pupil)
        {
            _pupils.Add(pupil);
        }

        public void Delete(Guid id)
        {
            var removedPupil = _pupils.FirstOrDefault(p => p.Id.Equals(id));
            if (removedPupil != null)
            {
                _pupils.Remove(removedPupil);
            }
            else
            {
                throw new Exception($"Id= {id} o`quvchi topilmadi!");
            }
        }

        public IEnumerable<Pupil> GetAll()
        {
            return _pupils;
        }

        public Pupil GetById(Guid id)
        {
            var SelectedPupil = _pupils.FirstOrDefault(p => p.Id.Equals(id));
            if (SelectedPupil == null) throw new Exception($"Id= {id} o`quvchi topilmadi!");
            return SelectedPupil;
        }

        public Pupil TheBestPupil()
        {
            return _pupils.OrderByDescending(x => x.Subjects.Max(s => s.Grades.Count(g => g.Equals(5)))).FirstOrDefault();
        }
        public void Update(Pupil obj)
        {
            int index = _pupils.FindIndex(x => x.Id.Equals(obj.Id));
            _pupils[index] = obj;
        }
    }
}
