using Prototype.Models;
using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = new ConsoleKeyInfo();
            while (!(key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.NumPad4))
            {
                key = ShowMenu();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        TestShallowCopy();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        TestDeepCopy();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        TestClone();
                        break;
                }
            }
        }

            private static void Wait()
            {
                Console.WriteLine("Press ESC to continue...");
                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
            }

            private static ConsoleKeyInfo ShowMenu()
            {
                Console.Clear();
                Console.WriteLine("1. Test ShallowCopy");
                Console.WriteLine("2. Test DeepCopy");
                Console.WriteLine("3. Test Clone");
                Console.WriteLine("4. Exit");
                return Console.ReadKey();
            }

        private static void TestShallowCopy()
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);
            Person p2 = p1.ShallowCopy();

            Console.Clear();
            Console.WriteLine("TestShallowCopy");
            Console.WriteLine("Original values of p1, p2");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            p1.Age = 32;
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;

            Console.WriteLine("\nValues of p1 and p2 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            Wait();
        }

        private static void TestDeepCopy()
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);
            Person p2 = p1.DeepCopy();

            Console.Clear();
            Console.WriteLine("TestDeepCopy");
            Console.WriteLine("Original values of p1, p2");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            p1.Age = 32;
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;

            Console.WriteLine("\nValues of p1 and p2 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            Wait();
        }

        private static void TestClone()
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);
            Person p2 = p1.Clone();

            Console.Clear();
            Console.WriteLine("TestClone");
            Console.WriteLine("Original values of p1, p2");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            p1.Age = 32;
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;

            Console.WriteLine("\nValues of p1 and p2 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);

            Wait();
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}",p.Name, p.Age);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}
