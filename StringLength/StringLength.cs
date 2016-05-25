namespace StringLength
{
    using System;

    class StringLength
    {
        static void Main()
        {
            string toCheck = Console.ReadLine();
            toCheck = toCheck.Replace(@"\", string.Empty);
            Console.WriteLine(toCheck.PadRight(20, '*'));
        }
    }
}
