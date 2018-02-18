using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextParserWebApp.Models
{
    public class OptionsList
    {
        public Dictionary<int, string> List { get; set; } = 
            new Dictionary<int, string> {
                { 1, "Count the number of all words in the text" },
                {2, "Count the number of digits in the text" },
                {3, "Count the number of words without numbers in the text" },
                {4, "Count the number of sentences in the text" },
                {5, "Find the most common word in the text" },
                {6, "Find the most frequent symbol in the text" } };
    }
}