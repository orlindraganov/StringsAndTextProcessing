using System;
using System.Linq;
using System.Text;

public class ExtractSentences
{
    public static void Main(string[] args)
    {
        var word = Console.ReadLine();
        var text = Console.ReadLine();
        Console.WriteLine(ExtratSentencesFromText(text, word));
    }

    private static string ExtratSentencesFromText(string text, string wordToFind)
    {
        var extractedText = new StringBuilder();

        var allSentense = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToArray();
        for (int i = 0; i < allSentense.Length; i++)
        {
            if (FindWordInSentance(allSentense[i], wordToFind))
            {
                extractedText.Append(allSentense[i]);
                extractedText.Append('.');

                if (i < allSentense.Length)
                {
                    extractedText.Append(" ");
                }
            }
        }

        return extractedText.ToString();
    }

    private static bool FindWordInSentance(string sentance, string word)
    {
        bool isFind = false;
        var nextIndexOfWord = sentance.IndexOf(word);

        var lastIndex = sentance.Length - word.Length;

        while (nextIndexOfWord > -1)
        {
            if (nextIndexOfWord != 0 &&
              ((char.IsLetter(sentance[nextIndexOfWord - 1])) ||
               (sentance[nextIndexOfWord - 1] == '-')))
            {
                nextIndexOfWord = sentance.IndexOf(word, nextIndexOfWord + 1);
            }
            else if (nextIndexOfWord < lastIndex &&
                ((char.IsLetter(sentance[nextIndexOfWord + word.Length]) ||
                (sentance[nextIndexOfWord + word.Length] == '-'))))
            {
                nextIndexOfWord = sentance.IndexOf(word, nextIndexOfWord + 1);
            }
            else
            {
                isFind = true;
                break;
            }
        }

        return isFind;
    }
}

//namespace ExtractSentences
//{
//    using System;
//    using System.Linq;
//    using System.Text;
//    using System.Globalization;
//    using System.Threading;


//    class ExtractSentences
//    {
//        static void Main()
//        {
//            Thread.CurrentThread.CurrentCulture = CultureInfo.Inv;
//            var toSearch = Console.ReadLine();
//            var text = Console.ReadLine();
//            Console.WriteLine(Extract(toSearch, text));

//        }

//        static string Extract(string toSearch, string text)
//        {
//            char[] splitter = { '.' };
//            var sentences = text.Trim().Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToArray();
//            var output = new StringBuilder();
//            foreach (var sentence in sentences)
//            {
//                if (sentence.Length < toSearch.Length)
//                {
//                    continue;
//                }
//                else if (sentence.ToLower() == toSearch.ToLower())
//                {
//                    output.Append(sentence.Trim());
//                    output.Append(". ");
//                    continue;
//                }
//                int index = sentence.IndexOf(toSearch, 0, StringComparison.OrdinalIgnoreCase);
//                while (index != -1)
//                {
//                    if (index == 0
//                    && !char.IsLetter(sentence[index + toSearch.Length]))
//                    {
//                        output.Append(sentence.Trim());
//                        output.Append(". ");
//                        break;
//                    }
//                    else if (index > 0
//                    && index + toSearch.Length < sentence.Length
//                    && !char.IsLetter(sentence[index - 1])
//                    && !char.IsLetter(sentence[index + toSearch.Length]))
//                    {
//                        output.Append(sentence.Trim());
//                        output.Append(". ");
//                        break;
//                    }
//                    else if (index + toSearch.Length == sentence.Length
//                    && !char.IsLetter(sentence[index - 1]))
//                    {
//                        output.Append(sentence.Trim());
//                        output.Append(". ");
//                        break;
//                    }
//                    index = sentence.IndexOf(toSearch, index + 1, StringComparison.OrdinalIgnoreCase);
//                }
//            }
//            return output.ToString().Trim();



//        }
//    }
//}


//using System;
//using System.Globalization;
//using System.Text;
//using System.Threading;

//public class ExtractSentences
//{
//    public static void Main(string[] args)
//    {
//        Thread.CurrentThread.CurrentCulture =
//  CultureInfo.InvariantCulture;
//        var word = Console.ReadLine();
//        var text = Console.ReadLine();

//        Console.WriteLine(ExtratSentencesFromText(text, word));
//    }

//    private static string ExtratSentencesFromText(string text, string wordToFind)
//    {
//        var extractedText = new StringBuilder();
//        wordToFind = wordToFind.ToLower();

//        var allSentense = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

//        for (int i = 0; i < allSentense.Length; i++)
//        {
//            ////foreach (string word in allSentense[i].Split(' '))
//            ////{
//            ////    if (word.Trim(',', ';', ':','2',' ').ToLower() == wordToFind.ToLower())
//            ////    {
//            ////        extractedText.Append(allSentense[i]);
//            ////        extractedText.Append('.');
//            ////        break;
//            ////    }
//            ////}

//            if (wordToFind.ToLower() == allSentense[i].ToLower())
//            {
//                extractedText.Append(allSentense[i]);
//                extractedText.Append('.');
//                break;
//            }
//            else if (wordToFind.Length >= allSentense[i].Length)
//            {
//                continue;
//            }

//            var nextStartIndex = allSentense[i].ToLower().IndexOf(wordToFind);

//            while (nextStartIndex != -1)
//            {
//                var currentIndex = nextStartIndex;
//                var tempStart = 0;
//                var tempEnd = 0;
//                char symbolBefore = '0';
//                char symbolAfter = '0';

//                if (currentIndex == 0)
//                {
//                    tempEnd = currentIndex + wordToFind.Length;
//                    symbolAfter = allSentense[i][tempEnd];
//                }
//                else if (currentIndex + wordToFind.Length - 1 == allSentense[i].Length - 1)
//                {
//                    tempStart = currentIndex - 1;
//                    symbolBefore = allSentense[i][tempStart];
//                }
//                else
//                {
//                    tempStart = currentIndex - 1;
//                    tempEnd = currentIndex + wordToFind.Length;
//                    symbolBefore = allSentense[i][tempStart];
//                    symbolAfter = allSentense[i][tempEnd];
//                }

//                if (!char.IsLetter(symbolBefore) && !char.IsLetter(symbolAfter))
//                {
//                    extractedText.Append(allSentense[i]);
//                    extractedText.Append('.');
//                    break;
//                }

//                if (currentIndex + wordToFind.Length - 1 < allSentense[i].Length)
//                {
//                    nextStartIndex = allSentense[i].ToLower().IndexOf(wordToFind, currentIndex + 1);
//                }
//                else
//                {
//                    break;
//                }
//            }
//        }

//        return extractedText.ToString();
//    }
//}
