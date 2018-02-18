using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextParser;
using TextParser.Classes;

namespace TextParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = "../../testText.txt";

            //CountingWords counterW = new CountingWords();
            //try
            //{
            //    FileParser parser = new FileParser(path, counterW);
            //    Console.WriteLine("File name - " + parser.FileName);
            //    Console.WriteLine("File size - " + parser.FileSize);
            //    KeyValuePair<String, int> pair = parser.TryParse();
            //    Console.WriteLine(pair.Key + " - " + pair.Value);
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}

            //CountingSentences counterS = new CountingSentences();
            //try
            //{
            //    FileParser parser = new FileParser(path, counterS);
            //    Console.WriteLine("File name - " + parser.FileName);
            //    Console.WriteLine("File size - " + parser.FileSize);
            //    KeyValuePair<String, int> pair = parser.TryParse();
            //    Console.WriteLine(pair.Key + " - " + pair.Value);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //СountingNumbers counterN = new СountingNumbers();
            //try
            //{
            //    FileParser parser = new FileParser(path, counterN);
            //    Console.WriteLine("File name - " + parser.FileName);
            //    Console.WriteLine("File size - " + parser.FileSize);
            //    KeyValuePair<String, int> pair = parser.TryParse();
            //    Console.WriteLine(pair.Key + " - " + pair.Value);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //СountingNotNumbers counterNN = new СountingNotNumbers();
            //try
            //{
            //    FileParser parser = new FileParser(path, counterNN);
            //    Console.WriteLine("File name - " + parser.FileName);
            //    Console.WriteLine("File size - " + parser.FileSize);
            //    KeyValuePair<String, int> pair = parser.TryParse();
            //    Console.WriteLine(pair.Key + " - " + pair.Value);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //FrequentWord frequentW = new FrequentWord();
            //try
            //{
            //    FileParser parser = new FileParser(path, frequentW);
            //    Console.WriteLine("File name - " + parser.FileName);
            //    Console.WriteLine("File size - " + parser.FileSize);
            //    KeyValuePair<String, int> pair = parser.TryParse();
            //    Console.WriteLine(pair.Key + " - " + pair.Value);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            FrequentChar frequentC = new FrequentChar();
            try
            {
                FileParser parser = new FileParser(path, frequentC);
                Console.WriteLine("File name - " + parser.FileName);
                Console.WriteLine("File size - " + parser.FileSize);
                KeyValuePair<String, int> pair = parser.TryParse();
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
