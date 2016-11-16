using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class CsvReader2
    {
        public static IEnumerable<T> ReadСsv2<T>(string filename) where T : class, new()
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
                    yield return GetObject<T>(header, str.Replace("\"", "").Split(','));
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

        private static T GetObject<T>(string[] props, string[] str) where T : class, new()
        {
            var obj = new T();

            for (int i = 0; i < props.Length; i++)
            {
                var propInfo = typeof(T).GetProperties().FirstOrDefault(x => x.Name == props[i]);
                if (propInfo != null)
                {
                    var convertedValue = Converter.ConvertFor<T>(propInfo.Name, str[i]);
                    propInfo.SetValue(obj, convertedValue);
                }
            }

            return obj;
        }
    }
}
