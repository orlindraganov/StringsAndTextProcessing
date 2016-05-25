namespace ReverseString
{
    using System;
    using System.Text;

    class ReverseString
    {
        static string Reverse(string input)
        {
            StringBuilder reverse = new StringBuilder();
            foreach (char letter in input)
            {
                reverse.Insert(0, letter);
            }
            return reverse.ToString();
        }

        static void Main()
        {
            string toReverse = Console.ReadLine();
            Console.WriteLine(Reverse(toReverse));
        }
    }
}
