using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab15_PSTU_2023
{
    public class Stadium
    {
        private int _lenght = 0;
        private int _height = 0;
        private float _barrierPercent = 0;

        public Stadium(int lenght)
        {
            Lenght = lenght;
        }

        public int Lenght
        {
            get => _lenght;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                _lenght = value;
            }
        }
        
        public int Height
        {
            get => _height;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value)); 
                _height = value;
            }
        }
        
        public float BarrierPercent
        {
            get => _barrierPercent;
            set
            {
                if (value is > 100 or < -1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _barrierPercent = value;
            }
        }

        public List<int> Race(List<Runner> runners, float barrierPercent)
        {
            List<List<int>> track = CreateTrack(runners.Count);
            FillTrack(ref track, barrierPercent);
            List<int> result = new List<int>();
            for (int i = 0; i < Height; i++)
            {
                int j = i;
                Thread thread = new Thread((() => Run(ref result, track[j], j)));
                thread.Start();
            }

            return result;
        }

        public List<List<int>> CreateTrack(int height)
        {
            Height = height;
            
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < Height; i++)
            {
                result.Add(new List<int>());
                for (int j = 0; j < Lenght; j++)
                {
                    result[i].Add(0);
                }
            }
            return result;
        }

        public void FillTrack(ref List<List<int>> track, float barrierPercent)
        {
            BarrierPercent = barrierPercent;
            Random rand = new Random();
            int count = 0;
            int barrierElement = (int)(Height * Lenght * (BarrierPercent / 100));
            while (count != barrierElement)
            {
                int x = rand.Next(Height);
                int y = rand.Next(Lenght);

                if (track[x][y] == 0)
                {
                    track[x][y] = 1;
                    count += 1;
                }

            }
        }

        public void Run(ref List<int> result, List<int> runnerPath, int runnerNumber)
        {
            for (int i = 0; i < runnerPath.Count; i++)
            {
                if (runnerPath[i] == 1)
                {
                    Console.WriteLine("--------");
                    Thread.Sleep(300);
                }
                Thread.Sleep(10);
                Console.WriteLine($"Бегун {runnerNumber} пробежал одну позицию");
            }
            Console.WriteLine($"Бегун {runnerNumber} закончил бежать.");
            result.Add(runnerNumber);
        }
    }
}  