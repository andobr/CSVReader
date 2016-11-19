using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    public class CsvReader3<T>
    {
        public static IEnumerable<Dictionary<string, object>> ReadCsv3(string filename)
        {
            return FileReader.ReadFile(filename, GetObject);
        }

        private static Dictionary<string, object> GetObject(string[] props, string[] str)
        {
            var obj = new Dictionary<string, object>();
            for (var i = 0; i < props.Length; i++)
            {
                var res = Converter.ConvertFor<T>(props[i], str[i]);
                obj.Add(props[i], res);
            }
            return obj;
        }
    }
}
