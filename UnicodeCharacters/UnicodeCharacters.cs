namespace UnicodeCharacters
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    class UnicodeCharacters
    {
        static Dictionary<string, string> EscSeqDicitonary =
              new Dictionary<string, string>()
              {
                { @"\'", "0027" },
                { @"\""", "0022" },
                { @"\\", "005C" },
                { @"\0", "0000" },
                { @"\a", "0007" },
                { @"\b", "0008" },
                { @"\f", "000C" },
                { @"\n", "000A" },
                { @"\r", "000D" },
                { @"\t", "0009" },
                { @"\v", "000B" }
              };
        static void Main()
        {
            string text = Console.ReadLine();
            var output = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {

                output.Append(@"\u");
                output.Append(((int)text[i]).ToString("X").PadLeft(4, '0'));
            }
            Console.WriteLine(output.ToString().ToLower());
        }
    }
}
