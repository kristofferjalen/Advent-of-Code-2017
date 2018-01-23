class Day9B
{
    static void Main()
    {
        var lines = System.IO.File.ReadAllLines("input");

        var removed = 0;

        foreach (var line in lines)
        {
            var garbage = false;

            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == '!')
                    i++;
                else if (garbage && c == '>')
                    garbage = false;
                else if (garbage)
                    removed++;
                else if (c == '<')
                    garbage = true;
            }
        }

        System.Console.WriteLine(removed); // 5101
    }
}