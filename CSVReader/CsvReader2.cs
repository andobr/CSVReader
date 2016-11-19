using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    public class CsvReader2<T> where T : new()
    {
        public static IEnumerable<T> ReadCsv2(string filename)
        {
            return FileReader.ReadFile(filename, GetObject);
        }

        private static T GetObject(string[] props, string[] str)
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
