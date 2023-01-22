using ZadanieOtDimi.Models;

namespace ZadanieOtDimi.Services;

public static class AnimalService
{
    public static void WorkWithAnimal(ApplicationContext db)
    {
        PrintAnimal(db);
        Thread.Sleep(2000);
        
        Console.Write("\nВыберите вариант сортировки:\n" +
                      "1. По имени\n" +
                      "2. По возрасту\n" +
                      "3. По породе\n" +
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
}