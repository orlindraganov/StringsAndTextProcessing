namespace EncodeDecode
{
    using System;
    using System.Text;


    class EncodeDecode
    {
        static void Main()
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();
            Console.WriteLine(Encode(text, key));
        }

        static string Encode(string text, string key)
        {
            var encoded = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                encoded.Append((char)(text[i] ^ key[i % key.Length]));
            }
            return encoded.ToString();
        }

    }
}
