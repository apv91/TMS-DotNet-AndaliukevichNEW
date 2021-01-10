using System;
using System.Globalization;

namespace DayInputHandler
{
    class Program
    {
        static void Main(string[] args)
        {

            DayInputHandler();

            Console.WriteLine("Нажми любую кнопку для завершения программы.");
            Console.ReadKey();

        }

        static void DayInputHandler()
        {
            DateTime DayToStart;
            DateTime DayToEnd;

            Console.Write("Введи начальную дату : ");
            DayToStart = DayInputCheck(Console.ReadLine(), "Введи начальную дату : ");

            Console.Write("Введи конечную дату : ");
            DayToEnd = DayInputCheck(Console.ReadLine(), "Введи конечную дату : ");

            if (DayToStart < DayToEnd)
            {
                DayOutputHandler(DayToStart, DayToEnd);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка : Конечная дата больше начальной!");
                Console.ResetColor();

                DayInputHandler();
            }

        }
        static void DayOutputHandler(DateTime dayToStart, DateTime dayToEnd)
        {
            DayOfWeek dayOfWeek;

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Начальная дата : " + dayToStart.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine("Конечная дата : " + dayToEnd.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine("--------------------------------");

            Console.Write("Введи день недели для поиска : ");

            dayOfWeek = DayOfWeekInputCheck(Console.ReadLine(), "Введи день недели для поиска: ");

            Console.WriteLine("День недели введен : " + dayOfWeek);
            Console.WriteLine("--------------------------------");

            while (dayToEnd >= dayToStart)
            {
                if (dayToStart.DayOfWeek == dayOfWeek)
                {
                    Console.WriteLine(dayToStart.ToString("dd/MM/yyyy - dddd", CultureInfo.InvariantCulture));
                }
                dayToStart = dayToStart.AddDays(1);
            }

        }

        static DayOfWeek DayOfWeekInputCheck(string dayOfWeekInput, string request)
        {
            try
            {
                DayOfWeek dayOfWeek = Enum.Parse<DayOfWeek>(dayOfWeekInput);
                return dayOfWeek;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : Invalid Input!");
                Console.ResetColor();

                Console.Write(request);

                return DayOfWeekInputCheck(Console.ReadLine(), request);
            }
        }

        static DateTime DayInputCheck(string dayInput, string request)
        {
            DateTime dayOutput;

            try
            {
                return dayOutput = DateTime.Parse(dayInput);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : Input is Incorrect!");
                Console.ResetColor();

                Console.Write(request);

                return DayInputCheck(Console.ReadLine(), request);
            }

        }
    }
}