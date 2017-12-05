using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp17
{
    using SquarePredicates = List<Func<(int x, int y, int value), bool>>;

    class Day3B
    {
        static void Main()
        {
            var table = new List<(int x, int y, int value)> { (0, 0, 1) };

            int i = 1, x = 0, y = 0, s = 1;

            int SumOfSquareValues(IEnumerable<Func<(int x, int y, int value), bool>> f) => 
                f.Sum(ff => table.SingleOrDefault(ff).value);

            int Sum(int v)
            {
                while (i <= v)
                {
                    for (var j = 0; j < s; j++)
                    {
                        x++;
                        i = SumOfSquareValues(new SquarePredicates
                        {
                            z => z.x == x - 1 && z.y == y,
                            z => z.x == x - 1 && z.y == y - 1,
                            z => z.x == x && z.y == y - 1,
                            z => z.x == x + 1 && z.y == y - 1
                        });
                        table.Add((x, y, i));
                        if (i > v)
                            return i;
                    }
                    for (var j = 0; j < s; j++)
                    {
                        y--;
                        i = SumOfSquareValues(new SquarePredicates
                        {
                            z => z.x == x - 1 && z.y == y - 1,
                            z => z.x == x - 1 && z.y == y,
                            z => z.x == x - 1 && z.y == y + 1,
                            z => z.x == x && z.y == y + 1
                        });
                        table.Add((x, y, i));
                        if (i > v)
                            return i;
                    }
                    s++;

                    for (var j = 0; j < s; j++)
                    {
                        x--;
                        i = SumOfSquareValues(new SquarePredicates
                        {
                            z => z.x == x - 1 && z.y == y + 1,
                            z => z.x == x && z.y == y + 1,
                            z => z.x == x + 1 && z.y == y + 1,
                            z => z.x == x + 1 && z.y == y
                        });
                        table.Add((x, y, i));
                        if (i > v)
                            return i;
                    }
                    for (var j = 0; j < s; j++)
                    {
                        y++;
                        i = SumOfSquareValues(new SquarePredicates
                        {
                            z => z.x == x && z.y == y - 1,
                            z => z.x == x + 1 && z.y == y - 1,
                            z => z.x == x + 1 && z.y == y,
                            z => z.x == x + 1 && z.y == y + 1
                        });
                        table.Add((x, y, i));
                        if (i > v)
                            return i;
                    }
                    s++;
                }
                return i;
            }

            var result = Sum(368078); // 369601

            Console.WriteLine(result);
        }
    }
}
