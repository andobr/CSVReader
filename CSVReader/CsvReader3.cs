using System.Collections.Generic;
using System.Linq;

namespace CSVReader
{
    public class CsvReader3
    {
        public static IEnumerable<Dictionary<string, object>> ReadСsv3(string filename)
        {
            var list = CsvReader1.ReadСsv1(filename).ToList();
            var header = list.First().ToList().Select(x => x.Replace("\"", "").Replace(".", "")).ToArray();
            list.RemoveAt(0);
            foreach (var str in list)
            {
                yield return GetObject(header, str);
            }
        }

        private static Dictionary<string, object> GetObject(string[] props, string[] str)
        {
            var obj = new Dictionary<string, object>();

            for (var i = 0; i < props.Length; i++)
            {
                var res = Converter.ConvertFor<AirQualityInfo>(props[i], str[i]);
                obj.Add(props[i], res);
            }

            return obj;
        }
    }
}
