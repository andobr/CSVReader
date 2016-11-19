using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    public class CsvReader4<T>
    {
        public static IEnumerable<dynamic> ReadCsv4(string filename)
        {
            return FileReader.ReadFile(filename, GetObject);
        }

        private static dynamic GetObject(string[] props, string[] str)
        {
            var obj = new ExpandoObject();
            var expando = (IDictionary<string, object>) obj;
            for (var i = 0; i < props.Length; i++)
            {
                var res = Converter.ConvertFor(props[i], str[i], typeof(T));
                expando.Add(props[i], res);
            }
            return obj;
        }
    }
}
