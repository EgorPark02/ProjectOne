using ZadanieOtDimi.Services;

namespace ZadanieOtDimi;

internal class Program
{
    public static void Main(string[] args)
    {
        using var db = new ApplicationContext();
        while (true)
        {
            CommonService.GetRequestText();
            var value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
            {
                CommonService.InvalidCommandAction();
            }
            else
            {
                switch (value.ToLower())
                {
                    case "1":
                    {
                        AnimalService.WorkWithAnimal(db);
                        break;
                    }
                    case "2":
                    {
                        UserService.WorkWithUser(db);
                        break;
                    }
                    case "3":
                    {
                        CityService.WorkWithCity(db);
                        break;
                    }
                    case "r":
                    {
                        CommonService.InvalidCommandAction("Сброс...");
                        break;
                    }
                    case "e":
                        return;
                    default:
                    {
                        CommonService.InvalidCommandAction();
                        break;
                    }
                }
            }
        }
    }
}