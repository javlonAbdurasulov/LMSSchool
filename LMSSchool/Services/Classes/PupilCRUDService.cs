using LMSSchool.Models;
using LMSSchool.Services.Intefaces;

namespace LMSSchool.Services.Classes
{
    internal class PupilCRUDService : IPupilCRUDService
    {
        private List<Pupil> _pupils = new();
        public Dictionary<string, byte> AvaregeGrade()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, IEnumerable<byte>> CountOfFiveGradesForEachSubject()
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
            return _pupils.OrderBy(x => x.Subjects.Max(s => s.Grades.Count(g => g.Equals(5)))).FirstOrDefault();

        }
        public void Update(Pupil obj)
        {
            int index = _pupils.FindIndex(x => x.Id.Equals(obj.Id));
            _pupils[index] = obj;
        }
    }
}
