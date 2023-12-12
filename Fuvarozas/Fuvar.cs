using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvarozas
{
    internal class Fuvar
    {
        public int taxiId { get; set; }
        public DateTime start { get; set; }
        public int length_in_ms { get; set; }
        public float distance { get; set; }
        public float price { get; set; }
        public float tip { get; set; }
        public string paymentMethod { get; set; }

        public Fuvar(int _taxiId, string _start, int _length_in_ms, float _distance, float _price, float _tip, string _paymentMethod)
        {
            taxiId = _taxiId;
            start = DateTime.ParseExact(_start, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            length_in_ms = _length_in_ms;
            distance = _distance;
            price = _price;
            tip = _tip;
            paymentMethod = _paymentMethod;
        }
    }
}
