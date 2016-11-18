using System.Collections.Generic;
using System.Linq;

namespace CSVReader
{
    public class CsvReader2
    {
        public static IEnumerable<T> ReadСsv2<T>(string filename) where T : new()
        {
            var list = CsvReader1.ReadСsv1(filename).ToList();
            var header = list.First().ToArray();
            list.RemoveAt(0);
            foreach (var str in list)
            {
                yield return GetObject<T>(header, str);
            }
        }

        private static T GetObject<T>(string[] props, string[] str) where T : new()
        {
            var obj = new T();

            for (int i = 0; i < props.Length; i++)
            {
                var property = typeof(T).GetProperty(props[i]);
                if (property == null) continue;
                var res = Converter.ConvertFor<T>(property.Name, str[i]);
                property.SetValue(obj, res);
            }

            return obj;
        }
    }
}
