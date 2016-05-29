
namespace ParseURL
{
    using System;
    using System.Text;

    class Parse
    {
        static void Main()
        {
            var url = Console.ReadLine();
            string[] details = new string[3];
            details = ParseURL(url);
            Console.WriteLine("[protocol] = {0}", details[0]);
            Console.WriteLine("[server] = {0}", details[1]);
            if (details.Length == 3)
            {
                Console.WriteLine("[resource] = /{0}", details[2]);
            }
            else
            {
                Console.WriteLine("[resource] = /");
            }
        }

        static string[] ParseURL(string url)
        {
            var splitters = new string[] { @"://", @"/" };
            var details = new string[3];
            details = url.Split(splitters, 3, StringSplitOptions.RemoveEmptyEntries);
            return details;
        }
    }
}
