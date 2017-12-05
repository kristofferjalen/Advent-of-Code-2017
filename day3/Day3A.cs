using System;

namespace ConsoleApp17
{
    class Day3A
    {
        static void Main()
        {
            int i = 1, x = 0, y = 0, s = 1;
            
            int Steps(int v)
            {
                while (i < v)
                {
                    for (var j = 0; j < s; j++)
                    {
                        x++;
                        if (++i == v)
                            return Math.Abs(x) + Math.Abs(y);
                    }
                    for (var j = 0; j < s; j++)
                    {
                        y--;
                        if (++i == v)
                            return Math.Abs(x) + Math.Abs(y);
                    }
                    s++;

                    for (var j = 0; j < s; j++)
                    {
                        x--;
                        if (++i == v)
                            return Math.Abs(x) + Math.Abs(y);
                    }
                    for (var j = 0; j < s; j++)
                    {
                        y++;
                        if (++i == v)
                            return Math.Abs(x) + Math.Abs(y);
                    }
                    s++;
                }
                return 0;
            }

            var steps = Steps(368078); // 371

            Console.WriteLine(steps);
        }
    }
}
