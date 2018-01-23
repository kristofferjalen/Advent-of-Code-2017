using System;

namespace ConsoleApp1
{
    class Day23B
    {
        static void Main()
        {
            var b = 99 * 100 + 100000;
            var c = b + 17000;
            var h = 0;

            while (true)
            {
                var f = 1;

                // How many numbers are composite (non-prime)?
                for (var d = 2; d < b; d++)
                {
                    if (b % d == 0)
                    {
                        f = 0;
                        break;
                    }
                }

                if (f == 0)
                    h++;

                if (b == c)
                    break;

                b += 17;
            }

            Console.WriteLine(h); // 913
        }
    }
}