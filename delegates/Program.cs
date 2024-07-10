using System;

namespace delegates
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
                try
                {
                    // Массив из пяти различных видов исключений
                    int[] numbers = { 1, 2, 3 };
                    Console.WriteLine(numbers[4]); // IndexOutOfRangeException

                    int a = 10, b = 0;
                    int result = a / b; // DivideByZeroException

                    string str = null;
                    Console.WriteLine(str.Length); // NullReferenceException

                    throw new CustomException("Custom Exception"); // CustomException
                }
                // Обработка исключений
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("IndexOutOfRangeException: " + e.Message);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("DivideByZeroException: " + e.Message);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("NullReferenceException: " + e.Message);
                }
                catch (CustomException e)
                {
                    Console.WriteLine("CustomException: " + e.Message);
                }
                // Блок finally (необязательный)
                finally
                {
                    Console.WriteLine("Finally block always executes.");
                }
            }
        }
    }