using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day18A
    {
        static void Main()
        {
            var instructions = System.IO.File.ReadAllLines("input");
            
            var registers = new Dictionary<string, long>(instructions
                .Where(x => !int.TryParse(x.Split(' ')[1], out var _))
                .Select(x => x.Split(' ')[1])
                .Distinct()
                .Select(x => new KeyValuePair<string, long>(x, 0)));
            
            long freq = 0;

            var i = 0;
            
            while (i >= 0 && i < instructions.Count())
            {
                var args = instructions[i].Split(' ');
                var op = args[0];
                var arg1 = args[1];
                var arg2 = args.Length == 3 ? args[2] : "";

                if (op == "set")
                {
                    registers[arg1] = long.TryParse(arg2, out var result) ? result : registers[arg2];
                }
                else if (op == "add")
                {
                    registers[arg1] += long.TryParse(arg2, out var result) ? result : registers[arg2];
                }
                else if (op == "mul")
                {
                    registers[arg1] *= long.TryParse(arg2, out var result) ? result : registers[arg2];
                }
                else if (op == "mod")
                {
                    registers[arg1] %= long.TryParse(arg2, out var result) ? result : registers[arg2];
                }
                else if (op == "snd")
                {
                    freq = int.TryParse(arg1, out var result) ? result : registers[arg1];
                }
                else if (op == "rcv")
                {
                    long result = long.TryParse(arg1, out result) ? result : registers[arg1];
                    if (result != 0)
                        break;
                }
                else if (op == "jgz")
                {
                    long result = long.TryParse(arg1, out result) ? result : registers[arg1];
                    if (result > 0)
                    {
                        long jump = long.TryParse(arg2, out jump) ? jump : registers[arg2];
                        i += (int)jump - 1;
                    }
                }

                i++;
            }

            Console.WriteLine(freq); // 8600
        }
    }
}
