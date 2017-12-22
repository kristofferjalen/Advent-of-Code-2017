class Day15A
{
    static void Main()
    {
        long a = 873, b = 583;
        int matches = 0, i = 0;

        while (i++ < 40_000_000)
        {
            a = a * 16807 % 2147483647;
            b = b * 48271 % 2147483647;

            if ((a & 0b1111_1111_1111_1111) == (b & 0b1111_1111_1111_1111))
                matches++;
        }

        System.Console.WriteLine(matches); // 631
    }
}