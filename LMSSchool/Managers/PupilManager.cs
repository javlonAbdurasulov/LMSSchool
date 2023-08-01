using LMSSchool.Events;
using LMSSchool.Models;
using LMSSchool.Services.Classes;
using LMSSchool.Services.Intefaces;

namespace LMSSchool.Managers;

internal class PupilManager
{
    private readonly IPupilCRUDService _pupilCRUDService;
    public PupilManager()
    {
        _pupilCRUDService = new PupilCRUDService();
    }
    public void Run()
    {
        bool davom = true;
        while (davom)
        {
            Console.WriteLine("PupilManager ga xush kelibsiz?");
            Console.WriteLine("1. O`quvchi qo'shish");
            Console.WriteLine("2. O`quvchilarni ko'rish");
            Console.WriteLine("3. O`quvchini yangilash");
            Console.WriteLine("4. O`quvchini o'chirish");
            Console.WriteLine("5. Eng Yaxshi o`quvchi");
            Console.WriteLine("6. O`quvchini har bir fandan olgan 5  baholarini soni");
            Console.WriteLine("7. O`quvchini har bir fandan olgan o`rtacha  bahosi.");
            Console.WriteLine("0. Dasturdan chiqish");
            Console.Write("Tanlang: ");

            int tanlov = Convert.ToInt32(Console.ReadLine());

            switch (tanlov)
            {
                case 0:
                    davom = false;
                    break;
                case 1:

                    _pupilCRUDService.Create(new Pupil());
                    break;
                case 2:
                    PrintPupil(_pupilCRUDService.GetAll());
                    break;
                case 3:
                    Pupil pupil = new();
                    _pupilCRUDService.Update(pupil);
                    OnObjectUpdatedModel.OnObjectUpdated.Invoke(pupil);

                    break;
                case 4:
                    //  TaomniOchirish();
                    break;
                case 5:
                    //  EngQimmatOvqat();
                    break;
                case 6:
                    //  EngKopBuyurtma();
                    break;
                case 7:
                    //  EngKamBuyurtma();
                    break;
                default:
                    Console.WriteLine("Noto'g'ri tanlov!");
                    break;
            }

            Console.WriteLine();
        }

    }
    private static void PrintPupil(IEnumerable<Pupil> pupilOUT)
    {
        foreach (var item in pupilOUT)
        {
            Console.WriteLine(item);

            foreach (var item2 in item)
            {
                Console.WriteLine(item2);
            }
        }
    }
}