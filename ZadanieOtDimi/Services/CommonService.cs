namespace ZadanieOtDimi.Services;

public static class CommonService
{
    public static void GetRequestText()
    {
        Console.Clear();
        Console.Write("Из какой таблицы вывести данные?\n" +
                      "1. Animal\n" +
                      "2. User\n" +
                      "3. City\n" +
                      "Введите цифру для вывода соответствующей таблицы: ");
    }

    public static void InvalidCommandAction(string message = "Неверная команда")
    {
        Console.Clear();
        Console.WriteLine(message);
        Thread.Sleep(2000);
    }

    public static void PressAnyKey()
    {
        Console.WriteLine("\nНажмите любую кнопку для продолжения...");
        Console.ReadKey();
    }
}