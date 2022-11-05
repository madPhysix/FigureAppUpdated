using System;

namespace FigureApp
{
    public static class HelperClass
    {
        public static int ParseStringToInt(string input)
        {
            while (true)
            {
                if (int.TryParse(input, out int parsedInt))
                    return parsedInt;
                else 
                    Console.WriteLine("Input is in incorrect format.");
            }
        }
    }
}
