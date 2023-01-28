using ZadanieOtDimi.Models;

namespace ZadanieOtDimi.Services;

public static class AnimalService
{
    public static void WorkWithAnimal(ApplicationContext db)
    {
        while (true)
        {
            PrintAnimal(db);
            Thread.Sleep(2000);
            
            Console.Write("\nЧто необходимо сделать с таблицей:\n" +
                          "1. Сортировка по имени\n" +
                          "2. Сортировка по возрасту\n" +
                          "3. Сортировка по породе\n" +
                          "4. Добавить объект в таблицу\n" +
                          "5. Удалить объект из таблицы\n" +
                          "6. Изменить объект из таблицы\n" +
                          "E. Выход\n" +
                          "Введите значение: ");
            
            var sortNumber = Console.ReadLine();
            switch (sortNumber.ToLower())
            {
                case "1":
                {
                    Console.Clear();
                    var animalSortWithName = db.Animals.OrderBy(a => a.Name);
                    
                    PrintSortedAnimal(animalSortWithName);
                    CommonService.PressAnyKey();
                    break;
                }
                case "2":
                {
                    Console.Clear();
                    var animalSortWithAge = db.Animals.OrderBy(a => a.Age);
                    
                    PrintSortedAnimal(animalSortWithAge);
                    CommonService.PressAnyKey();
                    break;
                }
                case "3":
                {
                    Console.Clear();
                    var animalSortWithBreed = db.Animals.OrderBy(a => a.Breed);
                    
                    PrintSortedAnimal(animalSortWithBreed);
                    CommonService.PressAnyKey();
                    break;
                }
                case "4":
                {
                    Console.Clear();
                    PrintAnimal(db);
                    AddNewAnimal(db);
                    PrintAnimal(db);
                    CommonService.InvalidCommandAction("Объект добавлен в таблицу...");
                    break;
                }
                case "5":
                {
                    Console.Clear();
                    PrintAnimal(db);
                    DeleteAnimal(db);
                    PrintAnimal(db);
                    CommonService.InvalidCommandAction("Объект удалён из таблицы...");
                    break;
                }
                case "6":
                {
                    Console.Clear();
                    PrintAnimal(db);
                    ChangeAnimal(db);
                    PrintAnimal(db);
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
                    CommonService.GetRequestText();
                    break;
                }
            }
        }
    }

    private static void PrintAnimal(ApplicationContext db)
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("| Id  |    Name    | Age |            Breed           |");
        Console.WriteLine("-------------------------------------------------------");
        
        foreach (var animal in db.Animals.ToList())
        {
            Console.WriteLine("| {0, 3} | {1, 10} | {2, 3} | {3, 26} |", animal.Id, animal.Name, animal.Age, animal.Breed);
            Console.WriteLine("-------------------------------------------------------");
        }
    }
    
    private static void PrintSortedAnimal(IOrderedQueryable<Animal> animalSortWithName)
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("| Id  |    Name    | Age |            Breed           |");
        Console.WriteLine("-------------------------------------------------------");
        
        foreach (var animal in animalSortWithName)
        {
            Console.WriteLine("| {0, 3} | {1, 10} | {2, 3} | {3, 26} |", animal.Id, animal.Name, animal.Age, animal.Breed);
            Console.WriteLine("-------------------------------------------------------");
        }
    }

    private static void AddNewAnimal(ApplicationContext db)
    {
        Console.Write("Введите имя животного: ");
        string name = Console.ReadLine();

        Console.Write("Введите возраст животного: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите породу животного: ");
        string breed = Console.ReadLine();

        var animal = new Animal() {Name = name, Age = age, Breed = breed};
        db.Animals.Add(animal);
        db.SaveChanges();
    }

    private static void DeleteAnimal(ApplicationContext db)
    {
        Console.Write("Введите ID животного для удаления: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var animal = db.Animals.FirstOrDefault(a => a.Id == id);
        
        db.Animals.Remove(animal);
        db.SaveChanges();
    }

    private static void ChangeAnimal(ApplicationContext db)
    {
        Console.Write("Введите ID животного для изменения: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var animal = db.Animals.FirstOrDefault(a => a.Id == id);
        
        Console.Write("Введите имя для животного: ");
        string? name = Console.ReadLine();
        
        Console.Write("Введите возраст для животного: ");
        int age = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Введите породу для животного: ");
        string? breed = Console.ReadLine();

        if (animal != null)
        {
            animal.Name = name;
            animal.Age = age;
            animal.Breed = breed;
            db.Animals.Update(animal);
        }

        db.SaveChanges();
    }
}