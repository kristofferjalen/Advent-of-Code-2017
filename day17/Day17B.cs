class Day17B
{
    static void Main()
    {
        int after0 = 0, curr = 0, i = 1;

        while (i <= 50_000_000)
        {
            curr = (curr + 370) % i++;

            if (curr++ == 0)
                after0 = i - 1;
        }

        System.Console.WriteLine(after0); // 11162912
    }
}
