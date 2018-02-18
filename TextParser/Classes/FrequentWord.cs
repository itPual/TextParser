using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextParser.Classes
{
    public class FrequentWord : IParse
    {
        private int count = 0;
        private string max = "";
        public KeyValuePair<string, int> Parse(FileInfo file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    Dictionary<string, int> dic = new Dictionary<string, int>();
                    string pattern = @"\b\w+\b";
                    count = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                        Match m = r.Match(line);
                        while (m.Success)
                        {
                            if (!dic.ContainsKey(m.Value))
                                dic.Add(m.Value, 1);
                            else
                                dic[m.Value]++;
                            m = m.NextMatch();
                        }
                    }
                    max = dic.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                    count = dic[max];
                }
            }
            catch (Exception e)
            {
                throw new Exception("The file could not be read: " + e.Message);
            }
            KeyValuePair<String, int> pair = new KeyValuePair<string, int>(max, count);
            return pair;
        }
    }
}
