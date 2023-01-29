using ZadanieOtDimi.Models;

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
            
            
            Console.Write("\nЧто необходимо сделать с таблицей:\n" +
                          "1. Сортировка по названию города\n" +
                          "2. Добавить город\n" +
                          "3. Удалить город\n" +
                          "4. Изменить город\n" +
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
                case "2":
                {
                    Console.Clear();
                    PrintCity(db);
                    AddCity(db);
                    PrintCity(db);
                    CommonService.InvalidCommandAction("Объект добавлен в таблицу...");
                    break;
                }
                case "3":
                {
                    Console.Clear();
                    PrintCity(db);
                    DeleteCity(db);
                    PrintCity(db);
                    CommonService.InvalidCommandAction("Объект удалён из таблицы...");
                    break;
                }
                case "4":
                {
                    Console.Clear();
                    PrintCity(db);
                    ChangeCity(db);
                    PrintCity(db);
                    CommonService.InvalidCommandAction("Данные изменены...");
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

    private static void AddCity(ApplicationContext db)
    {
        try
        {
            Console.Write("Введите название города: ");
            string? name = Console.ReadLine();
        
            var city = new City { NameCity = name};
            db.Cities.Add(city);
            db.SaveChanges();
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("Возникла ошибка");
            Thread.Sleep(2000);
            PrintCity(db);
            AddCity(db);
        }
        
    }

    private static void DeleteCity(ApplicationContext db)
    {
        try
        {
            Console.Write("Введите ID города для удаления: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var city = db.Cities.FirstOrDefault(c => c.Id == id);
            if (city != null) db.Cities.Remove(city);
            db.SaveChanges();
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("Возникла ошибка");
            Thread.Sleep(2000);
            PrintCity(db);
            DeleteCity(db);
        }
    }

    private static void ChangeCity(ApplicationContext db)
    {
        try
        {
            Console.Write("Введите ID города для изменения: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var city = db.Cities.FirstOrDefault(c => c.Id == id);
        
            Console.Write("Введите название города для изменения: ");
            string? name = Console.ReadLine();
        
            if (city != null)
            {
                city.NameCity = name;
                db.Cities.Update(city);
            }
        
            db.SaveChanges();
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("Возникла ошибка");
            Thread.Sleep(2000);
            PrintCity(db);
            ChangeCity(db);
        }
    }
}