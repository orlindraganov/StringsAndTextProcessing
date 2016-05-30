namespace ConsoleApplication1
{

    using System;


    class CorrectBrackets
    {
        static bool CheckBrackets(string input, char[] brackets)
        {
            int bracketCount = 0;
            foreach (char symbol in input)
            {
                if (symbol == brackets[0])
                {
                    bracketCount++;
                }
                else if (symbol == brackets[1])
                {
                    bracketCount--;
                }
                if (bracketCount < 0)
                {
                    return false;
                }
            }
            if (bracketCount != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        static void Main()
        {
            string toCheck = Console.ReadLine();
            char[] brackets = new char[] { '(', ')' };
            Console.WriteLine(CheckBrackets(toCheck, brackets) ? "Correct" : "Incorrect");
        }
    }
}
