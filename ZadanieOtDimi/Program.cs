namespace ZadanieOtDimi;

using System.Threading;

internal class Program
{
    public static void Main(string[] args)
    {
        using var db = new ApplicationContext();
        while (true)
        {
            GetRequestText();
            var value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
            {
                InvalidCommandAction();
            }
            else
            {
                switch (value.ToLower())
                {
                    case "1":
                    {
                        WorkWithAnimal(db);
                        break;
                    }
                    case "2":
                    {
                        WorkWithUser(db);
                        break;
                    }
                    case "3":
                    {
                        WorkWithCity(db);
                        break;
                    }
                    case "r":
                    {
                        InvalidCommandAction("Сброс...");
                        break;
                    }
                    case "e":
                        return;
                    default:
                    {
                        InvalidCommandAction();
                        break;
                    }
                }
            }
        }
    }

    #region City

    private static void WorkWithCity(ApplicationContext db)
    {
        while (true)
        {
            Console.Clear();
            PrintCity(db);

            Console.Write("\nВыберите вариант сортировки:\n" +
                          "1. По названию города\n" +
                          "Введите значение: ");

            var sortNumber = Console.ReadLine();
            switch (sortNumber)
            {
                case "1":
                {
                    Console.Clear();
                    Console.WriteLine("| Id | City |");

                    foreach (var city in db.Cities.OrderBy(c => c.NameCity))
                    {
                        Console.WriteLine($"| {city.Id} | {city.NameCity} |");
                    }

                    PressAnyKey();
                    return;
                }
                default:
                {
                    InvalidCommandAction("Такой сортировки нет");
                    break;
                }
            }
        }
    }

    private static void PrintCity(ApplicationContext db)
    {
        Console.WriteLine("| Id | City |");
        foreach (var city in db.Cities.ToList())
        {
            Console.WriteLine($"| {city.Id} | {city.NameCity} |");
        }
    }

    #endregion


    #region User

    private static void WorkWithUser(ApplicationContext db)
    {
        while (true)
        {
            Console.Clear();
            PrintUser(db);

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
                    PressAnyKey();
                    break;
                }
                case "2":
                {
                    var userSortedByAge = db.Users.OrderBy(a => a.Age);
                    PrintSortedUser(userSortedByAge);
                    PressAnyKey();
                    break;
                }
                case "e":
                {
                    return;
                }
                default:
                {
                    InvalidCommandAction("Такой сортировки нет");
                    break;
                }
            }
        }
    }

    private static void PrintUser(ApplicationContext db)
    {
        Console.WriteLine("| Id |    Name   | Age |");
        foreach (var user in db.Users.ToList())
        {
            Console.WriteLine($"| {user.Id} | {user.Name} | {user.Age} |");
        }
    }

    private static void PrintSortedUser(IOrderedQueryable<User> sortedUser)
    {
        Console.Clear();
        Console.WriteLine("| Id |    Name   | Age |");
        foreach (var user in sortedUser)
        {
            Console.WriteLine($"| {user.Id} | {user.Name} | {user.Age} |");
        }
    }

    #endregion


    private static void WorkWithAnimal(ApplicationContext db)
    {
        PrintAnimal(db);
        Thread.Sleep(3000);
        Console.Write("Выберите вариант сортировки:\n" +
                      "1. По имени\n" +
                      "2. По возрасту\n" +
                      "3. По породе\n" +
                      "Введите значение:");
        var sortNumber = Console.ReadLine();
        switch (sortNumber)
        {
            case "1":
                Console.Clear();
                var animalSortWithName = db.Animals.OrderBy(a => a.Name);
                Console.WriteLine("|   Id   |   Name  | Age |    Breed    |");
                foreach (var a in animalSortWithName)
                {
                    Console.WriteLine("| {0, 1} | {1, 7} |  {2, 1}  | {3, 1} |", a.Id, a.Name, a.Age, a.Breed);
                }

                break;
            case "2":
                Console.Clear();
                var animalSortWithAge = db.Animals.OrderBy(a => a.Age);
                Console.WriteLine("Id|   Name  | Age |    Breed");
                foreach (var a in animalSortWithAge)
                {
                    Console.WriteLine("{0, 1} | {1, 7} |  {2, 1}  | {3, 1}", a.Id, a.Name, a.Age, a.Breed);
                }

                break;
            case "3":
                Console.Clear();
                var animalSortWithBreed = db.Animals.OrderBy(a => a.Breed);
                Console.WriteLine("Id|   Name  | Age |    Breed");
                foreach (var a in animalSortWithBreed)
                {
                    Console.WriteLine("{0, 1} | {1, 7} |  {2, 1}  | {3, 1}", a.Id, a.Name, a.Age, a.Breed);
                }

                break;
            default:
                Console.Clear();
                Console.WriteLine("Такой сортировки нет");
                Thread.Sleep(2700);
                Console.Clear();
                Console.Write("Выберите вариант сортировки:\n" +
                              "1. По имени\n" +
                              "2. По возрасту\n" +
                              "3. По породе\n" +
                              "Введите значение:");
                break;
        }
    }

    private static void PrintAnimal(ApplicationContext db)
    {
        Console.WriteLine("| Id |   Name  | Age |    Breed    |");
        foreach (var animal in db.Animals.ToList())
        {
            Console.WriteLine($"| {animal.Id} | {animal.Name} |  {animal.Age}  | {animal.Breed} |");
        }
    }

    #region Common

    private static void GetRequestText()
    {
        Console.Clear();
        Console.Write("Из какой таблицы вывести данные?\n" +
                      "1. Animal\n" +
                      "2. User\n" +
                      "3. City\n" +
                      "Введите цифру для вывода соответствующей таблицы: ");
    }

    private static void InvalidCommandAction(string message = "Неверная команда")
    {
        Console.Clear();
        Console.WriteLine(message);
        Thread.Sleep(2000);
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("\nНажмите любую кнопку для продолжения...");
        Console.ReadKey();
    }

    #endregion
}