using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class CsvReader1 
    {
        public static IEnumerable<string[]> ReadСsv1(string filename)
        {
            using (var stream = new StreamReader(filename))
            {
                while (true)
                {
                    var str = stream.ReadLine();
                    if (str == null)
                    {
                        stream.Close();
                        yield break;
                    }
                    yield return str.Replace("\"", "").Split(',').Select(x => x == "NA" ? null : x).ToArray();
                }
            }
        }
    }
}
