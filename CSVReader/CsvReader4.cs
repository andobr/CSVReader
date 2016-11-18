using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CSVReader
{
    public class CsvReader4
    {
        public static IEnumerable<dynamic> ReadCsv4(string filename)
        {
            var list = CsvReader1.ReadСsv1(filename).ToList();
            var header = list.First().ToArray();
            list.RemoveAt(0);
            foreach (var str in list)
            {
                yield return GetObject(header, str);
            }
        }

        private static dynamic GetObject(string[] props, string[] str)
        {
            var obj = new ExpandoObject();
            var expando = (IDictionary<string, object>) obj;

            for (var i = 0; i < props.Length; i++)
            {
                var res = Converter.ConvertFor<AirQualityInfo>(props[i], str[i]);
                expando.Add(props[i], res);
            }

            return obj;
        }
    }
}
