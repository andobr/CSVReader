using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    class AirQualityInfo
    {
        public string Name { get; set; }

        public int? Ozone { get; set; }

        public int? SolarR { get; set; }

        public double Wind { get; set; }

        public int Temp { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }
    }
}
