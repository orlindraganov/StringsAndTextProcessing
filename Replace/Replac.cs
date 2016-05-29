namespace Replace
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    class Replace
    {
        public const string openTagBegin = @"<a href=""";
        public const string openTagEnd = @""">";
        public const string closeTag = "</a>";

        static void Main()
        {
            var text = Console.ReadLine();
            var indexes = FindIndexes(text);
            var output = new StringBuilder();
            if (indexes.Count == 0)
            {
                output.Append(text);
            }
            else
            {
                output.Append(text.Substring(0, indexes[0]));
                for (int i = 0; i <= indexes.Count - 3; i++)
                {
                    output.Append("[");
                    output.Append(text.Substring(indexes[i + 1] + openTagEnd.Length, indexes[i + 2] - indexes[i + 1] - openTagEnd.Length));
                    i++;

                    output.Append("](");
                    output.Append(text.Substring(indexes[i - 1] + openTagBegin.Length, indexes[i] - indexes[i - 1] - openTagBegin.Length));
                    i++;

                    output.Append(")");
                    if (i != indexes.Count - 1)
                    {
                        output.Append(text.Substring(indexes[i] + closeTag.Length, indexes[i + 1] - indexes[i] - closeTag.Length));
                    }
                    else
                    {
                        output.Append(text.Substring(indexes[i] + closeTag.Length, text.Length - indexes[i] - closeTag.Length));
                    }
                }
            }
            Console.WriteLine(output);
        }

        static List<int> FindIndexes(string html)
        {
            var indexes = new List<int>();
            var openBeginIndex = html.IndexOf(openTagBegin);
            var openEndIndex = html.IndexOf(openTagEnd, openBeginIndex + 1);
            var closeIndex = html.IndexOf(closeTag);

            while (openBeginIndex != -1)
            {
                indexes.Add(openBeginIndex);
                indexes.Add(openEndIndex);
                closeIndex = html.IndexOf(closeTag, openEndIndex + 1);
                indexes.Add(closeIndex);
                openBeginIndex = html.IndexOf(openTagBegin, openBeginIndex + 1);
                if (openBeginIndex != -1)
                {
                    openEndIndex = html.IndexOf(openTagEnd, openBeginIndex + 1);
                }
            }
            return indexes;
        }

    }
}
