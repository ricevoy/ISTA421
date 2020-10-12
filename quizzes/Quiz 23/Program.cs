using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Quiz_23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is C# Quiz 23");
            Console.WriteLine("Enter the highest number to find primes: ");
            string input = Console.ReadLine();
            long findTo = long.Parse(input);
            List<long> primes = new List<long>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, findTo + 1, x =>
            {
                bool foundP = isPrime(x);
                if (foundP)
                {
                    primes.Add(x);

                }
            });
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            //output
            Console.WriteLine("PRINTING PRIMES");
            foreach (int element in primes)
                Console.Write($" {element} ");
            Console.WriteLine($"\n\nfound primes in time {ts}");
        }

        private static bool isPrime(long n)
        {
            bool isP = true;
            for (int i = 2; i <= (int)Math.Sqrt(n); i++)
                if (n % i == 0)
                {
                    isP = false;
                    break;
                }
            return isP;
        }
    }
}

