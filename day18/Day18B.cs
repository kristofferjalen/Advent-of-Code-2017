using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day18B
    {
        public static string[] Instructions { get; set; }

        static void Main()
        {
            Instructions = System.IO.File.ReadAllLines("input");

            var registers = Instructions
                .Where(x => !int.TryParse(x.Split(' ')[1], out var _))
                .Select(x => x.Split(' ')[1])
                .Distinct()
                .Select(x => new KeyValuePair<string, long>(x, 0))
                .ToList();

            var m1 = new Machine
            {
                Registers = new Dictionary<string, long>(registers)
            };

            var m2 = new Machine
            {
                Registers = new Dictionary<string, long>(registers) { ["p"] = 1 },
                OtherQueue = m1.Queue
            };

            m1.OtherQueue = m2.Queue;

            while (true)
            {
                int i1 = m1.Index,
                    i2 = m2.Index;

                m1.Proceed();
                m2.Proceed();

                if (i1 == m1.Index && i2 == m2.Index)
                    break;
            }

            Console.WriteLine(m2.Sends); //  7239
        }
    }
    
    public class Machine
    {

        public Dictionary<string, long> Registers { get; set; }

        public Queue<long> Queue { get; set; } = new Queue<long>();

        public Queue<long> OtherQueue { get; set; }

        public int Sends { get; set; }

        public int Index { get; set; }

        private readonly Dictionary<string, Action<string, string>> _ops;

        public Machine()
        {
            _ops = new Dictionary<string, Action<string, string>>
            {
                { "set", (arg1, arg2) => Registers[arg1] = long.TryParse(arg2, out var result) ? result : Registers[arg2] },
                { "add", (arg1, arg2) => Registers[arg1] += long.TryParse(arg2, out var result) ? result : Registers[arg2] },
                { "mul", (arg1, arg2) => Registers[arg1] *= long.TryParse(arg2, out var result) ? result : Registers[arg2] },
                { "mod", (arg1, arg2) => Registers[arg1] %= long.TryParse(arg2, out var result) ? result : Registers[arg2] },
                { "snd", (arg1, arg2) =>
                    {
                        OtherQueue.Enqueue(long.TryParse(arg1, out var result) ? result : Registers[arg1]);
                        Sends++;
                    }
                },
                { "rcv", (arg1, arg2) =>
                    {
                        if (Queue.Count > 0)
                            Registers[arg1] = Queue.Dequeue();
                        else
                            Index--;
                    }
                },
                { "jgz", (arg1, arg2) =>
                    {
                        long result = long.TryParse(arg1, out result) ? result : Registers[arg1];
                        if (result <= 0)
                            return;
                        long jump = long.TryParse(arg2, out jump) ? jump : Registers[arg2];
                        Index += (int) jump - 1;
                    }
                }
            };
        }

        public void Proceed()
        {
            if (Index < 0 || Index >= Day18B.Instructions.Length)
                return;

            var args = Day18B.Instructions[Index].Split(' ');

            string op = args[0],
                    arg1 = args[1],
                    arg2 = args.Length == 3 ? args[2] : "";

            _ops[op](arg1, arg2);

            Index++;
        }
    }
}
