using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    public class CsvReader1
    {
        public static IEnumerable<string[]> ReadCsv1(string filename)
        {
            return FileReader.ReadFile(filename, (header, str) => str);
        }
    }
}
