using System;

namespace console_app_input
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name:");
            var name = Console.ReadLine();
            Console.WriteLine($"Name entered as: {name} ");
        }
    }
}

