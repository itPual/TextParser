using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public interface IParse
    {
        KeyValuePair<String, int> Parse(FileInfo file);
    }
}
