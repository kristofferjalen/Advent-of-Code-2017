using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem8
{
    class Problem8A
    {
        private class Register
        {
            public string Name { get; set; }

            public int Value { get; set; }
        }

        static void Main()
        {
            var lines = System.IO.File.ReadAllLines("input");
            
            var registers = lines.Select(x => x.Split(" ")[0]).Distinct().Select(x => new Register {Name = x}).ToList();

            var ops = new Dictionary<string, Func<int, int, bool>>
            {
                {">",  (x, y) => x >  y },
                {"<",  (x, y) => x <  y },
                {"==", (x, y) => x == y },
                {">=", (x, y) => x >= y },
                {"<=", (x, y) => x <= y },
                {"!=", (x, y) => x != y }
            };

            foreach (var line in lines)
            {
                var s = line.Split(" ");
                string r = s[0], i = s[1], c1 = s[4], c2 = s[5];
                int a = int.Parse(s[2]), c3 = int.Parse(s[6]);
                if (ops[c2](registers.Single(x => x.Name == c1).Value, c3))
                    registers.Single(x => x.Name == r).Value += i == "inc" ? a : -a;
            }
            
            Console.WriteLine(registers.Max(x => x.Value)); // 6061
        }
    }
}
