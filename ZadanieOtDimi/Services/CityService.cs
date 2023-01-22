namespace ZadanieOtDimi.Services;

public static class CityService
{
    public static void WorkWithCity(ApplicationContext db)
    {
        while (true)
        {
            Console.Clear();
            PrintCity(db);
            Thread.Sleep(2000);
            
            
            Console.Write("\nВыберите вариант сортировки:\n" +
                          "1. По названию города\n" +
                          "E. Выход\n" +
                          "Введите значение: ");

            var sortNumber = Console.ReadLine();
            switch (sortNumber)
            {
                case "1":
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("| Id  |      City     |");
                    Console.WriteLine("-----------------------");
                    

                    foreach (var city in db.Cities.OrderBy(c => c.NameCity))
                    {
                        Console.WriteLine("| {0, 3} | {1, 13} |", city.Id, city.NameCity);
                        Console.WriteLine("-----------------------");
                    }

                    CommonService.PressAnyKey();
                    return;
                }
                case "e":
                {
                    return;
                }
                default:
                {
                    CommonService.InvalidCommandAction("Такой сортировки нет");
                    break;
                }
            }
        }
    }

    private static void PrintCity(ApplicationContext db)
    {
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine("| Id  |      City     |");
        Console.WriteLine("-----------------------");
        foreach (var city in db.Cities.ToList())
        {
            Console.WriteLine("| {0, 3} | {1, 13} |", city.Id, city.NameCity);
            Console.WriteLine("-----------------------");
        }
    }
}