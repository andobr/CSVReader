using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class CsvReader4
    {
        public static IEnumerable<dynamic> ReadCsv4(string filename)
        {
            using (var stream = new StreamReader(filename))
            {
                var header = GetHeader(stream);
                while (true)
                {
                    var str = stream.ReadLine();
                    if (str == null)
                    {
                        stream.Close();
                        yield break;
                    }
                    yield return GetObject(header, str.Replace("\"", "").Split(','));
                }
            }
        }

        private static string[] GetHeader(StreamReader stream)
        {
            var header = stream.ReadLine();
            if (header == null)
            {
                stream.Close();
            }
            return header.Replace("\"", "").Replace(".", "").Split(',');
        }

        private static dynamic GetObject(string[] props, string[] str)
        {
            var result = new ExpandoObject();
            var expandoDict = (IDictionary<string, object>) result;

            for (int i = 0; i < props.Length; i++)
            {
                var res = Converter.ConvertFor<AirQualityInfo>(props[i], str[i]);
                expandoDict.Add(props[i], res);
            }

            return result;
        }
    }
}
