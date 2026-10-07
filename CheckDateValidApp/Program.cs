using System;
using DateTimeCheckerLib;

namespace CheckDateValidApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==========================================================");
            Console.WriteLine("          PROGRAM: CHECK DATE VALID (DateTimeChecker)    ");
            Console.WriteLine("==========================================================");

            if (args.Length >= 3 &&
                int.TryParse(args[0], out int d) &&
                int.TryParse(args[1], out int m) &&
                int.TryParse(args[2], out int y))
            {
                RunSingleCheck(d, m, y);
                return;
            }

            InteractiveMenu();
        }

        private static void RunSingleCheck(int day, int month, int year)
        {
            int daysInMonth = DateTimeChecker.DayInMonth(month, year);
            bool isValid = DateTimeChecker.CheckDate(day, month, year);

            Console.WriteLine($"\nInput Date : {day}/{month}/{year}");
            Console.WriteLine($"DayInMonth : {(month >= 1 && month <= 12 ? daysInMonth.ToString() : "0 (Invalid Month)")}");
            Console.WriteLine($"CheckDate  : {(isValid ? "VALID (True)" : "INVALID (False)")}");
        }

        private static void InteractiveMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Check DayInMonth(month, year)");
                Console.WriteLine("2. Check CheckDate(day, month, year)");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option (1-3): ");

                string? choice = Console.ReadLine();
                if (choice == "3") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Month: ");
                        if (int.TryParse(Console.ReadLine(), out int month))
                        {
                            Console.Write("Enter Year: ");
                            if (int.TryParse(Console.ReadLine(), out int year))
                            {
                                int days = DateTimeChecker.DayInMonth(month, year);
                                Console.WriteLine($"=> DayInMonth({month}, {year}) = {days}");
                            }
                            else Console.WriteLine("Invalid Year input.");
                        }
                        else Console.WriteLine("Invalid Month input.");
                        break;

                    case "2":
                        Console.Write("Enter Day: ");
                        if (int.TryParse(Console.ReadLine(), out int d))
                        {
                            Console.Write("Enter Month: ");
                            if (int.TryParse(Console.ReadLine(), out int m))
                            {
                                Console.Write("Enter Year: ");
                                if (int.TryParse(Console.ReadLine(), out int y))
                                {
                                    bool valid = DateTimeChecker.CheckDate(d, m, y);
                                    Console.WriteLine($"=> CheckDate({d}, {m}, {y}) = {valid}");
                                }
                                else Console.WriteLine("Invalid Year input.");
                            }
                            else Console.WriteLine("Invalid Month input.");
                        }
                        else Console.WriteLine("Invalid Day input.");
                        break;

                    default:
                        Console.WriteLine("Invalid option, please choose 1-3.");
                        break;
                }
            }
        }
    }
}
