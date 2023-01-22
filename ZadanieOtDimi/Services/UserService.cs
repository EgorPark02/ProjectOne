using ZadanieOtDimi.Models;

namespace ZadanieOtDimi.Services;

public static class UserService
{
    public static void WorkWithUser(ApplicationContext db)
    {
        while (true)
        {
            Console.Clear();
            PrintUser(db);
            Thread.Sleep(2000);

            Console.Write("\nВыберите вариант сортировки:\n" +
                          "1. По имени\n" +
                          "2. По возрасту\n" +
                          "E. Выход\n" +
                          "Введите значение: ");

            var sortNumber = Console.ReadLine();
            switch (sortNumber.ToLower())
            {
                case "1":
                {
                    var userSortedByName = db.Users.OrderBy(a => a.Name);
                    PrintSortedUser(userSortedByName);
                    CommonService.PressAnyKey();
                    break;
                }
                case "2":
                {
                    var userSortedByAge = db.Users.OrderBy(a => a.Age);
                    PrintSortedUser(userSortedByAge);
                    CommonService.PressAnyKey();
                    break;
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

    private static void PrintUser(ApplicationContext db)
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("| Id  |    Name    | Age |");
        Console.WriteLine("--------------------------");
        foreach (var user in db.Users.ToList())
        {
            Console.WriteLine("| {0, 3} | {1, 10} | {2, 3} |", user.Id, user.Name, user.Age);
            Console.WriteLine("--------------------------");
        }
    }

    private static void PrintSortedUser(IOrderedQueryable<User> sortedUser)
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.WriteLine("| Id  |    Name    | Age |");
        Console.WriteLine("--------------------------");
        foreach (var user in sortedUser)
        {
            Console.WriteLine("| {0, 3} | {1, 10} | {2, 3} |", user.Id, user.Name, user.Age);
            Console.WriteLine("--------------------------");
        }
    }
}