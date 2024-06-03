using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class ThermoType
    {
        private string _name;
        private string _imgPath;

        public ThermoType(string name, string imgPath)
        {
            Name = name;
            ImgPath = imgPath;
        }

        public string Name { get => _name; set => _name = value; }
        public string ImgPath { get => _imgPath; set => _imgPath = value; }
    }


}
