using System;

namespace ConsoleApp1
{
    class Day16A
    {
        static void Main()
        {
            var programs = "abcdefghijklmnop";

            var input = System.IO.File.ReadAllText("input");

            var moves = input.Split(',');

            foreach (var move in moves)
            {
                if (move.StartsWith("s"))
                {
                    var n = int.Parse(move.Substring(1));
                    programs = programs.Substring(programs.Length - n) + programs.Substring(0, programs.Length - n);
                }
                else if (move.StartsWith("x"))
                {
                    var a = int.Parse(move.Substring(1).Split('/')[0]);
                    var b = int.Parse(move.Substring(1).Split('/')[1]);
                    var temp = programs[a];
                    var chars = programs.ToCharArray();
                    chars[a] = programs[b];
                    chars[b] = temp;
                    programs = new string(chars);
                }
                else if (move.StartsWith("p"))
                {
                    var a = move.Substring(1).Split('/')[0];
                    var b = move.Substring(1).Split('/')[1];
                    var temp = programs.IndexOf(a, StringComparison.Ordinal);
                    var chars = programs.ToCharArray();
                    chars[programs.IndexOf(b, StringComparison.Ordinal)] = a.ToCharArray()[0];
                    chars[temp] = b.ToCharArray()[0];
                    programs = new string(chars);
                }
            }

            Console.WriteLine(programs); // fnloekigdmpajchb
        }
    }
}
