using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day23A
    {
        static void Main()
        {
            var instructions = System.IO.File.ReadAllLines("input");

            var registers = new Dictionary<string, long>
            {
                {"a", 0},
                {"b", 0},
                {"c", 0},
                {"d", 0},
                {"e", 0},
                {"f", 0},
                {"g", 0},
                {"h", 0}
            };

            int count = 0;

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
                else if (op == "sub")
                {
                    registers[arg1] -= long.TryParse(arg2, out var result) ? result : registers[arg2];
                }
                else if (op == "mul")
                {
                    registers[arg1] *= long.TryParse(arg2, out var result) ? result : registers[arg2];
                    count++;
                }
                else if (op == "jnz")
                {
                    long result = long.TryParse(arg1, out result) ? result : registers[arg1];
                    if (result != 0)
                    {
                        long jump = long.TryParse(arg2, out jump) ? jump : registers[arg2];
                        i += (int)jump - 1;
                    }
                }

                i++;
            }

            Console.WriteLine(count); // 
        }
    }
}