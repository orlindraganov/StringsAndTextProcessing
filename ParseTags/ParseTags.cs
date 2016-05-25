namespace ParseTags
{
    using System;
    using System.Text;

    class ParseTags
    {
        static string ChangeTextInTags(string text, string[] tags)
        {
            int openindex = text.IndexOf(tags[0], 0, StringComparison.OrdinalIgnoreCase);
            int closeindex = text.IndexOf(tags[1], 0, StringComparison.OrdinalIgnoreCase);
            while (openindex != -1 && closeindex != -1)
            {
                text = text.Replace(
                    text.Substring(
                        openindex,
                        closeindex - openindex),
                    text.Substring(
                        openindex,
                        closeindex - openindex).ToUpper());
                text = text.Remove(closeindex, tags[1].Length);
                text = text.Remove(openindex, tags[0].Length);
                openindex = text.IndexOf(tags[0], openindex - 1, StringComparison.OrdinalIgnoreCase);
                closeindex = text.IndexOf(tags[1], openindex + 1, StringComparison.OrdinalIgnoreCase);
            }
            return text;
        }


        static void Main()
        {
            string text = Console.ReadLine();
            string[] tags = new string[] { "<upcase>", "</upcase>" };
            Console.WriteLine(ChangeTextInTags(text, tags));
        }
    }
}
