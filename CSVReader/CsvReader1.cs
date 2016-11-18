using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    public class CsvReader1
    {
        private const string Na = "NA";

        private const char Sepatator = ',';

        public static IEnumerable<string[]> ReadСsv1(string filename)
        {
            using (var stream = new StreamReader(filename))
            {
                var header = ReadLine(stream)?.Select(x => x.Replace(".", "")).ToArray();
                if (header == null) yield break;
                yield return header;

                while (true)
                {
                    var str = ReadLine(stream)?.ToArray();
                    if (str == null) yield break;
                    if (str.Length != header.Length) throw new Exception("Размерность строки не совпадает с размерностью заголовка");
                    yield return str;
                }
            }
        }

        private static string[] ReadLine(StreamReader stream)
        {
            var header = stream.ReadLine()?.Replace("\"", "").Split(Sepatator).Select(x => x == Na ? null : x).ToArray();
            if (header == null) stream.Close();
            return header;
        }
    }
}
