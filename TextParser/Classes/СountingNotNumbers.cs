﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextParser.Classes
{
    public class СountingNotNumbers : IParse
    {
        private int count = 0;
        public KeyValuePair<string, int> Parse(FileInfo file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    string pattern = @"\b[A-Za-z]+\b";
                    count = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                        Match m = r.Match(line);
                        while (m.Success)
                        {
                            m = m.NextMatch();
                            count++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("The file could not be read: " + e.Message);
            }
            KeyValuePair<String, int> pair = new KeyValuePair<string, int>("Number of words (not numbers) in the text", count);
            return pair;
        }
    }
}
