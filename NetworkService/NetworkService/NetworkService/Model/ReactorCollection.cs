using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public static event EventHandler EntitiesChanged; // Event to notify when Entities change

        // Method to invoke EntitiesChanged event
        private static void OnEntitiesChanged()
        {
            EntitiesChanged?.Invoke(null, EventArgs.Empty);
        }
        public static void AddEntity(ReactorTemp entity)
        {
            _entities.Add(entity);
            entity.PropertyChanged += Entity_PropertyChanged;
            OnEntitiesChanged(); // Invoke event when entity is added
        }

        public static void RemoveEntity(ReactorTemp entity)
        {
            _entities.Remove(entity);
            OnEntitiesChanged(); // Invoke event when entity is removed
        }

        public static void Entity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // If any property of a ReactorTemp object changes, notify about the change in Entities
            OnEntitiesChanged();
        }

        public static List<int> GetAllId()
        {
            List<int> allId = new List<int>();
            foreach (var entity in _entities)
            {
                allId.Add(entity.Id);
            }

            return allId;
        }
        public static List<string> GetAllTitles()
        {
            List<string> allTitles = new List<string>();
            foreach (var entity in _entities)
            {
                allTitles.Add(entity.Title);
            }

            return allTitles;
        }
    }
}
