namespace SeriesOfLetters
{
    using System;
    using System.Text;

    class SeriesOfLetters
    {
        static void Main()
        {
            string text = Console.ReadLine();
            var output = new StringBuilder();
            output.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != text[i - 1])
                {
                    output.Append(text[i]);
                }
            }
            Console.WriteLine(output);
        }
    }
}
