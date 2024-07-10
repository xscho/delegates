using System;
using System.Collections.Generic;

// Создание собственного типа исключения
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}

class Program
{
    static List<string> surnames = new List<string> { "Smith", "Johnson", "Williams", "Jones", "Brown" };

    static void Main()
    {
        SortHandler sortHandler = new SortHandler();
        sortHandler.SortCompleted += OnSortCompleted;

        Console.WriteLine("Введите 1 для сортировки от А до Я или 2 для сортировки от Я до А:");

        try
        {
            int input = int.Parse(Console.ReadLine());

            if (input != 1 && input != 2)
            {
                throw new InvalidInputException("Неверный ввод. Пожалуйста, введите 1 или 2.");
            }

            if (input == 1)
            {
                surnames.Sort();
            }
            else if (input == 2)
            {
                surnames.Sort();
                surnames.Reverse();
            }

            sortHandler.OnSortCompleted(surnames);
        }
        catch (InvalidInputException e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Неверный формат ввода. Введите число 1 или 2.");
        }
    }

    static void OnSortCompleted(List<string> sortedSurnames)
    {
        foreach (var surname in sortedSurnames)
        {
            Console.WriteLine(surname);
        }
    }
}

public class SortHandler
{
    public event Action<List<string>> SortCompleted;

    public void OnSortCompleted(List<string> sortedSurnames)
    {
        SortCompleted?.Invoke(sortedSurnames);
    }
}
