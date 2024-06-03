using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class ReactorCollection
    {
        private static ObservableCollection<ReactorTemp> _entities;
        private static Dictionary<string, ThermoType> thermoTypes;
        private static ObservableCollection<Measurement> measurements;
        

        static ReactorCollection()
        {
            _entities = new ObservableCollection<ReactorTemp>();
            thermoTypes = new Dictionary<string, ThermoType>();
            Measurements = new ObservableCollection<Measurement>();
            ThermoType RTD = new ThermoType("RTD", @"../../Resources/RTD.jpg");
            ThermoType TC = new ThermoType("ThermoCouple", @"../../Resources/ThermoCouple.jpg");
            ThermoTypes.Add("RTD",RTD);
            ThermoTypes.Add("TC", TC);
        }

        public static ObservableCollection<ReactorTemp> Entities { get => _entities; set => _entities = value; }
        public static Dictionary<string, ThermoType> ThermoTypes { get => thermoTypes; set => thermoTypes = value; }
        public static ObservableCollection<Measurement> Measurements { get => measurements; set => measurements = value; }

        public static List<int> GetAllId()
        {
            List<int> allId = new List<int>();
            foreach (var entity in _entities)
            {
                allId.Add(entity.Id);
            }

            return allId;
        }
    }
}
