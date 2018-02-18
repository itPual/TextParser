using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser.Classes
{
    public class FrequentChar : IParse
    {
        private int count = 0;
        private char max;
        public KeyValuePair<string, int> Parse(FileInfo file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    Dictionary<char, int> dic = new Dictionary<char, int>();
                    count = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var chars = line.ToCharArray();
                        foreach (var item in chars)
                        {
                            if (item != ' ')
                            {
                                if (!dic.ContainsKey(item))
                                    dic.Add(item, 1);
                                else
                                    dic[item]++;
                            }
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
            KeyValuePair<String, int> pair = new KeyValuePair<string, int>(max.ToString(), count);
            return pair;
        }
    }
}
