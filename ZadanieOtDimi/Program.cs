namespace ZadanieOtDimi;
using System.Threading;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Из какой таблицы вывести данные?\n" +
                          "1. Animal\n" +
                          "2. User\n" +
                          "3. City\n" +
                          "Введите цифру для вывода соответствующей таблицы: ");
        using ApplicationContext db = new ApplicationContext();
        while (true)
        {
            var str = Console.ReadLine();
            if (string.IsNullOrEmpty(str)){}
            else
            {
                switch (str.ToLower())
                {
                    
                    case "1":
                        WorkWithAnimal(db);
                        return;
                    case "2":
                        WorkWithUser(db);
                        return;
                    case "3":
                        WorkWithCity(db);
                        return;
                    case "r":
                        Console.Clear();
                        Thread.Sleep(1200);
                        Console.WriteLine("Из какой таблицы вывести данные?\n" +
                                          "1. Animal\n" +
                                          "2. User\n" +
                                          "3. City\n" +
                                          "Введите цифру для вывода соответствующей таблицы");
                        break;
                    case "e":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверная команда");
                        Thread.Sleep(2600);
                        Console.Clear();
                        Console.WriteLine("Из какой таблицы вывести данные?\n" +
                                          "1. Animal\n" +
                                          "2. User\n" +
                                          "3. City\n" +
                                          "Введите цифру для вывода соответствующей таблицы");
                        break;
                }
            }
        }
    }

    private static void WorkWithCity(ApplicationContext db)
    {
        Console.Clear();
        
        PrintCity(db);
        Console.Write("Выберите вариант сортировки:\n" +
                      "1. По названию города\n" +
                      "Введите значение:");
        
        var sortNumber = Console.ReadLine();
        switch (sortNumber)
        {
            case "1":
                Console.Clear();
                var citySortWithNameCity = db.Cities.OrderBy(c => c.NameCity);
                Console.WriteLine("Id | City");
                foreach (City c in citySortWithNameCity)
                {
                    Console.WriteLine("{0, 2} | {1, 2}", c.Id, c.NameCity);
                }
                break;
            default:
                Console.Clear();
                Console.WriteLine("Такой сортировки нет");
                Thread.Sleep(2700);
                Console.Clear();
                Console.Write("Выберите вариант сортировки:\n" +
                              "1. По названию города\n" + 
                              "Введите значение:");
                break;
        }
    }

    private static void WorkWithUser(ApplicationContext db)
    {
        Console.Clear();
        PrintUser(db);
        Console.Write("Выберите вариант сортировки:\n" +
                      "1. По имени\n" +
                      "2. По возрасту\n" +
                      "Введите значение:");
        var sortNumber = Console.ReadLine();
        switch (sortNumber)
        {
            case "1":
                Console.Clear();
                var userSortWithName = db.Users.OrderBy(a => a.Name);
                Console.WriteLine(" Id |    Name   | Age");
                foreach (User u in userSortWithName)
                {
                    Console.WriteLine("{0,3} | {1,9} | {2,2}", u.Id, u.Name, u.Age);
                }

                break;
            case "2":
                Console.Clear();
                var userSortWithAge = db.Users.OrderBy(a => a.Age);
                Console.WriteLine(" Id |    Name   | Age");
                foreach (User u in userSortWithAge)
                {
                    Console.WriteLine("{0,3} | {1,9} | {2,2}", u.Id, u.Name, u.Age);
                }
                break;
            case "e":
                return;
            default:
                Console.Clear();
                Console.WriteLine("Такой сортировки нет");
                Thread.Sleep(2700);
                Console.Clear();
                Console.Write("Выберите вариант сортировки:\n" +
                              "1. По имени\n" +
                              "2. По возрасту\n" +
                              "Введите значение:");
                break;
        }
    }

    private static void WorkWithAnimal(ApplicationContext db)
    {
        Console.Clear();
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
                Console.WriteLine("Id|   Name  | Age |    Breed");
                foreach (Animal a in animalSortWithName)
                {
                    Console.WriteLine("{0, 1} | {1, 7} |  {2, 1}  | {3, 1}", a.Id, a.Name, a.Age, a.Breed);
                }

                break;
            case "2":
                Console.Clear();
                var animalSortWithAge = db.Animals.OrderBy(a => a.Age);
                Console.WriteLine("Id|   Name  | Age |    Breed");
                foreach (Animal a in animalSortWithAge)
                {
                    Console.WriteLine("{0, 1} | {1, 7} |  {2, 1}  | {3, 1}", a.Id, a.Name, a.Age, a.Breed);
                }
                break;
            case "3":
                Console.Clear();
                var animalSortWithBreed = db.Animals.OrderBy(a => a.Breed);
                Console.WriteLine("Id|   Name  | Age |    Breed");
                foreach (Animal a in animalSortWithBreed)
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
    
    private static void PrintCity(ApplicationContext db)
    {
        var cities = db.Cities.ToList();
        Console.WriteLine("Id | City");
        foreach (City c in cities)
        {
            Console.WriteLine("{0, 2} | {1, 2}", c.Id, c.NameCity );
        }
    }
    
    private static void PrintUser(ApplicationContext db)
    {
        var users = db.Users.ToList();
        Console.WriteLine(" Id |    Name   | Age");
        foreach (User u in users)
        {
            Console.WriteLine("{0,3} | {1,9} | {2,2}", u.Id, u.Name, u.Age);
        }
    }
    
    private static void PrintAnimal(ApplicationContext db)
    {
        var animals = db.Animals.ToList();
        Console.WriteLine("Id|   Name  | Age |    Breed");
        foreach (Animal a in animals)
        {
            Console.WriteLine("{0, 1} | {1, 7} |  {2, 1}  | {3, 1}", a.Id, a.Name, a.Age, a.Breed);
        }
    }
}














