using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_OA.Data
{
    public class Car
    {
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public int year { get; set; }
        public int price { get; set; }
        public double TCC_Rating { get; set; }
        public int Hwy_MPG { get; set; }
    }
}
