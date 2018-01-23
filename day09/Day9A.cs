class Day9A
{
    static void Main()
    {
        var lines = System.IO.File.ReadAllLines("input");

        var sum = 0;

        foreach (var line in lines)
        {
            var level = 0;
            var garbage = false;

            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == '!')
                    i++;
                else if (garbage && c == '>')
                    garbage = false;
                else if (garbage)
                    ;
                else if (c == '<')
                    garbage = true;
                else if (c == '{')
                    sum += ++level;
                else if (c == '}')
                    level--;
            }
        }

        System.Console.WriteLine(sum); // 10616
    }
}