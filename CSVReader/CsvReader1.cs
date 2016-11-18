using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    public class CsvReader1
    {
        private const string NA = "NA";

        public static IEnumerable<string[]> ReadСsv1(string filename)
        {
            using (var stream = new StreamReader(filename))
            {
                var header = ReadLine(stream);
                if (header == null) yield break;
                yield return header;

                while (true)
                {
                    var str = ReadLine(stream);
                    if (str == null) yield break;
                    if (str.Length != header.Length) throw new Exception("Размерность строки не совпадает с размерностью заголовка");
                    yield return str;
                }
            }
        }

        private static string[] ReadLine(StreamReader stream)
        {
            var header = stream.ReadLine()?.Replace("\"", "").Split(',').Select(x => x == NA ? null : x).ToArray();
            if (header == null)
            {
                stream.Close();
            }
            return header;
        }
    }
}
