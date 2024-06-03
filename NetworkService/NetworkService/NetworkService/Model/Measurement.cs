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
        private bool isValid;

        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public double Value { get => value; set => this.value = value; }
        public bool IsValid { get => isValid; set => isValid = value; }

        public Measurement(DateTime timestamp, double value, bool isValid)
        {
            this.timestamp = timestamp;
            this.value = value;
            this.isValid = isValid;
        }
    }
}
