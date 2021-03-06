﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextParser.Classes
{
    public class CountingWords : IParse
    {
        private int count = 0;
        public KeyValuePair<string, int> Parse(FileInfo file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    String pattern = @"[\s\u0022]\b";
                    count = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] elements = Regex.Split(line, pattern,RegexOptions.IgnoreCase);
                        count += elements.Length;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("The file could not be read: " + e.Message);
            }
            KeyValuePair<String, int> pair = new KeyValuePair<string, int>("Number of words in the text", count);
            return pair;
        }
    }
}
