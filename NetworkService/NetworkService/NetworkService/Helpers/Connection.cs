using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;

namespace NetworkService.Helpers
{
    public class Connection
    {
        public UIElement Source { get; set; }
        public UIElement Target { get; set; }
        public Line Line { get; set; }
    }
}
