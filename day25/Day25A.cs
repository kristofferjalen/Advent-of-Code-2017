using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day25A
    {
        static void Main()
        {
            var list = Enumerable.Repeat(0, 100000).ToList();
            
            var ops = new Dictionary<string, Func<int, int,(int,int,string)>>
            {
                {"A", (x,c) => x == 0 ? (1, c+1, "B") : (0, c-1, "C") },
                {"B", (x,c) => x == 0 ? (1, c-1, "A") : (1, c+1, "D") },
                {"C", (x,c) => x == 0 ? (1, c+1, "A") : (0, c-1, "E") },
                {"D", (x,c) => x == 0 ? (1, c+1, "A") : (0, c+1, "B") },
                {"E", (x,c) => x == 0 ? (1, c-1, "F") : (1, c-1, "C") },
                {"F", (x,c) => x == 0 ? (1, c+1, "D") : (1, c+1, "A") }
            };

            var state = "A";
            var index = list.Count / 2;
            var i = 0;
            while (i++ < 12173597)
            {
                var result = ops[state](list[index], index);
                list[index] = result.Item1;
                index = result.Item2;
                state = result.Item3;
            }

            var ones = list.Sum();

            Console.WriteLine(ones); // 2870
        }
    }
}
