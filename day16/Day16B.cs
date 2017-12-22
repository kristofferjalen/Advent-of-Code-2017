using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day16B
    {
        static void Main()
        {
            var programs = "abcdefghijklmnop";

            var input = System.IO.File.ReadAllText("input");

            var moves = input.Split(',');
            
            string Spin(string p, string m)
            {
                var n = int.Parse(m.Substring(1));
                return string.Concat(p.Substring(p.Length - n), p.Substring(0, p.Length - n));
            }

            string Exchange(string p, string m)
            {
                var split = m.Substring(1).Split('/');
                var b = int.Parse(split[1]);
                var temp = p[int.Parse(split[0])];
                var chars = p.ToCharArray();
                chars[int.Parse(split[0])] = p[b];
                chars[b] = temp;
                return new string(chars);
            }

            string Partner(string p, string m)
            {
                var s = m.Substring(1).Split('/');
                var temp = p.IndexOf(s[0], StringComparison.Ordinal);
                var c = p.ToCharArray();
                c[p.IndexOf(s[1], StringComparison.Ordinal)] = s[0].ToCharArray()[0];
                c[temp] = s[1].ToCharArray()[0];
                return new string(c);
            }

            var ops = new Dictionary<char, Func<string, string, string>>
            {
                { 's', Spin },
                { 'x', Exchange },
                { 'p', Partner }
            };

            var history = new List<string> { programs };

            while (true)
            {
                programs = moves.Aggregate(programs, (current, m) => ops[m[0]](current, m));

                if (history.Any(x => x == programs))
                {
                    var remainder = 1_000_000_000 % (long) history.Count;

                    for (var j = 0; j < remainder; j++)
                    {
                        programs = moves.Aggregate(programs, (current, m) => ops[m[0]](current, m));
                    }
                    break;
                }

                history.Add(programs);
            }

            Console.WriteLine(programs); // amkjepdhifolgncb
        }
    }
}
