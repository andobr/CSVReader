using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\Users\Anton\Source\Repos\CSVReader\CSVReader\airquality.csv";

            //foreach (var item in CsvReader1.ReadСsv1(filename))
            //{
            //    foreach (var s in item)
            //    {
            //        Console.Write(s + "\t");
            //    }
            //    Console.WriteLine();
            //}

            foreach (var item in CsvReader2.ReadСsv2<AirQualityInfo>(filename))
            {
                typeof(AirQualityInfo)
                .GetProperties()
                .Select(x => x.GetValue(item, null))
                .ToList()
                .ForEach(x => Console.Write(x + "\t"));
                Console.WriteLine();
            }

            //foreach (var item in CsvReader3.ReadСsv3(filename))
            //{
            //    foreach (var s in item)
            //    {
            //        Console.Write(s + "\t");
            //    }
            //    Console.WriteLine();
            //}

            //foreach (var item in CsvReader4.ReadCsv4(filename))
            //{
            //    foreach (var s in item)
            //    {
            //        Console.Write(s + "\t");
            //    }
            //    Console.WriteLine();
            //}

            Console.Read();
        }
    }
}
