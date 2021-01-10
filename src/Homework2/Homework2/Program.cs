using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите дату для определения дня недели:");
            string selection = Console.ReadLine();
            bool dayweek = DateTime.TryParse(selection, out DateTime date);
            if (dayweek)
            {
                Console.WriteLine(date.DayOfWeek);
            }
            else
            {
                Console.WriteLine("Неправильная дата! Введите дату в формате dd mm yyyy");
            }
            Console.ReadLine();
        }
    }
}
