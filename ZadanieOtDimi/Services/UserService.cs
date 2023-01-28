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

            Console.Write("\nЧто необходимо сделать с таблицей:\n" +
                          "1. Сортировка по имени\n" +
                          "2. Сортировка по возрасту\n" +
                          "3. Добавить нового пользователя\n" +
                          "4. Удалить пользователя\n" +
                          "5. Изменение пользователя\n" +
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
                case "3":
                {
                    Console.Clear();
                    PrintUser(db);
                    AddNewUser(db);
                    PrintUser(db);
                    CommonService.InvalidCommandAction("Объект добавлен в таблицу...");
                    break;
                }
                case "4":
                {
                    Console.Clear();
                    PrintUser(db);
                    DeleteUser(db);
                    PrintUser(db);
                    CommonService.InvalidCommandAction("Объект удалён из таблицы...");
                    break;
                }
                case "5":
                {
                    Console.Clear();
                    PrintUser(db);
                    ChangeUser(db);
                    PrintUser(db);
                    CommonService.InvalidCommandAction("Данные изменены...");
                    break;
                }
                case "e":
                {
                    return;
                }
                default:
                {
                    CommonService.InvalidCommandAction("Неверная команда");
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

    private static void AddNewUser(ApplicationContext db)
    {
        Console.Write("Введите имя пользователя: ");
        string name = Console.ReadLine();
        
        Console.Write("Введите его возраст: ");
        int age = Convert.ToInt32(Console.ReadLine());
        
        var user = new User { Name = name, Age = age };
        db.Users.Add(user);
        db.SaveChanges();
    }

    private static void DeleteUser(ApplicationContext db)
    {
        Console.Write("Введите ID пользователя для удаления: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var user = db.Users.FirstOrDefault(d => d.Id == id);
        
        db.Users.Remove(user);
        db.SaveChanges();
    }

    private static void ChangeUser(ApplicationContext db)
    {
        Console.Write("Введите ID пользователя для изменения: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var user = db.Users.FirstOrDefault(d => d.Id == id);
        
        Console.Write("Введите имя для пользователя: ");
        string? name = Console.ReadLine();
        
        Console.Write("Введите возраст пользователя: ");
        int age = Convert.ToInt32(Console.ReadLine());

        if (user != null)
        {
            user.Name = name;
            user.Age = age;
            db.Users.Update(user);
        }

        db.SaveChanges();
    }
}