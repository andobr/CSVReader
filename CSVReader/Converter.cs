using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSVReader
{
    class Converter
    {
        private const string na = "NA";

        private static readonly List<Type> types = new List<Type>() {typeof(int), typeof(double), typeof(string)}; 

        public static object ConvertFor<T>(string property, string value)
        {            
            var type = typeof(T).GetProperty(property).PropertyType;
            var underType = Nullable.GetUnderlyingType(type);
            return (underType == null) ? Convert(value, false, type) : Convert(value, true, underType);
        }

        private static object Convert(string value, bool isNullable, Type type)
        {
            TypeCheck(type);
            if (value == null || value.Equals(na) && !isNullable) throw new ArgumentException();
            return value.Equals(na) ? null : TypeDescriptor.GetConverter(type).ConvertFrom(null, CultureInfo.InvariantCulture, value);
        }

        private static void TypeCheck(Type type)
        {
            if (!types.Contains(type))
            {
                throw new TypeAccessException();
            }
        }
    }
}
