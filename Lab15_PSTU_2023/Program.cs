using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lab15_PSTU_2023
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Runner> runners = new List<Runner>();
            for (int i = 0; i < 10; i++)
            {
                runners.Add(new Runner());
            }
            Stadium stadium = new Stadium(10);
            List<int> result = stadium.Race(runners, 25);
            Console.WriteLine(result.Count);
        }
    }
}