class Day15B
{
    static void Main()
    {
        long a = 873, b = 583;
        int matches = 0, i = 0;

        while (i++ < 5_000_000)
        {
            do
            {
                a = a * 16807 % 2147483647;
            } while (a % 4 != 0);

            do
            {
                b = b * 48271 % 2147483647;
            } while (b % 8 != 0);

            if ((a & 0b1111_1111_1111_1111) == (b & 0b1111_1111_1111_1111))
                matches++;
        }

        System.Console.WriteLine(matches); // 279
    }
}