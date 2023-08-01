using LMSSchool.Models;

namespace LMSSchool.Services.Intefaces;

internal interface IPupilCRUDService : ICRUDBase<Pupil>
{
    public Pupil TheBestPupil();
    public Dictionary<string, IEnumerable<byte>> CountOfFiveGradesForEachSubject(IEnumerable<Pupil> pupils);
    public Dictionary<string, double> AvaregeGrade(IEnumerable<Pupil> pupils);
}
