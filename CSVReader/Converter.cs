using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace CSVReader
{
    internal class Converter
    {
        private static readonly List<Type> Types = new List<Type>() {typeof(int), typeof(int?), typeof(double), typeof(double?), typeof(string)}; 

        public static object ConvertFor(string property, string source, Type type)
        {
            var targetType = type.GetProperty(property)?.PropertyType;

            if (!Types.Contains(targetType)) throw new Exception($"Конвертирование в тип {targetType} не поддерживается");

            var underType = Nullable.GetUnderlyingType(targetType);
            
            // Если строка пустая и тип не является Nullable
            if (string.IsNullOrEmpty(source) && underType == null) throw new Exception($"Тип {targetType} не поддерживает значения null");

            if (string.IsNullOrEmpty(source)) return null;

            TypeConverter converter = TypeDescriptor.GetConverter(underType ?? targetType);

            if(!converter.IsValid(source)) throw new Exception($"{source} не является допустимым значением для {targetType}");

            return converter.ConvertFromString(null, CultureInfo.InvariantCulture, source);
        }
    }
}
