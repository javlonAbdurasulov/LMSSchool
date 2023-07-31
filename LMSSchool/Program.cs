

using LMSSchool.Managers;

namespace LMSSchool;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Select\n1.Pupil\n2.Subject");
                byte select = byte.Parse(Console.ReadLine());
                if (select == 1)
                {
                    new PupilManager().Run();
                }
                else if (select == 2)
                {
                    new SubjectManager().Run(); 
                }
                Console.Clear();
            }
        }
        catch (Exception e)
        {
            new ExceptionHandler.ExceptionHandler(e).Handle();
        }
    }
}