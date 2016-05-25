namespace SubStringInText
{
    using System;

    class SubStringInText
    {
        static int FindNumberOfSubstrings(string substring, string text)
        {
            int counter = -1;
            int lastIndex = 0;
            while (lastIndex != -1)
            {
                lastIndex = text.IndexOf(substring, lastIndex + 1, StringComparison.OrdinalIgnoreCase);
                counter++;
            }
            return counter;
        }

        static void Main()
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            Console.WriteLine(FindNumberOfSubstrings(pattern, text));


        }
    }
}
