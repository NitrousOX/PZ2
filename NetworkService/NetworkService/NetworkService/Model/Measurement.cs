using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class Measurement
    {
        private DateTime timestamp;
        private double value;

        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public double Value { get => value; set => this.value = value; }

        public Measurement(DateTime timestamp, double value)
        {
            this.timestamp = timestamp;
            this.value = value;
        }
    }
}
