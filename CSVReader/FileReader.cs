using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public static class FileReader
    {
        private const string Na = "NA";

        private const char Separator = ',';

        public static IEnumerable<T> ReadFile<T>(string filename, Func<string[], string[], T> csvReader)
        {
            using (var stream = new StreamReader(filename)) 
            {
                var header = ReadLine(stream)?.Select(x => x.Replace(".", "")).ToArray();
                while (true)
                {
                    var str = ReadLine(stream);
                    if (str == null || header == null) yield break;
                    if (header.Length != str.Length) throw new Exception("Размерность строки не совпадает с размерностью заголовка");
                    yield return csvReader(header, str);
                }
            }
        }

        private static string[] ReadLine(StreamReader stream)
        {
            var str = stream.ReadLine()?.Replace("\"", "").Split(Separator).Select(x => x == Na ? null : x).ToArray();
            if (str == null) stream.Close();
            return str;
        }
    }
}
