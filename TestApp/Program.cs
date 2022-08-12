using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;
            var tommorow = DateTime.Now.AddDays(1);
            TimeSpan timeSpan = tommorow.Subtract(now);

            Console.WriteLine(timeSpan);

            Console.ReadKey();
        }
    }
}
