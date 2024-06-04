using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NetworkService.ViewModel
{
    public class MeasurmentGraphViewModel : BindableBase
    {
        public List<Measurement> measurements;
        public MeasurmentGraphViewModel()
        {
            SelectedBadColor = ValueToColorConverter.ErrorColor;
            SelectedGoodColor = ValueToColorConverter.AcceptableColor;
        }

        public double MapValue(double x)
        {
            return 230 - ((x - 150) * (230 - 0) / (450 - 150)) + 0;
        }

        public void UpdateValues()
        {
            Time5 = measurements[4].Timestamp.ToString("HH:mm");
            Time4 = measurements[3].Timestamp.ToString("HH:mm");
            Time3 = measurements[2].Timestamp.ToString("HH:mm");
            Time2 = measurements[1].Timestamp.ToString("HH:mm");
            Time1 = measurements[0].Timestamp.ToString("HH:mm");

            Y5 = MapValue(measurements[4].Value);
            Y4 = MapValue(measurements[3].Value);
            Y3 = MapValue(measurements[2].Value);
            Y2 = MapValue(measurements[1].Value);
            Y1 = MapValue(measurements[0].Value);

            Y5t = Y5 + 20;
            Y4t = Y4 + 20;
            Y3t = Y3 + 20;
            Y2t = Y2 + 20;
            Y1t = Y1 + 20;

            Value5 = measurements[4].Value;
            Value4 = measurements[3].Value;
            Value3 = measurements[2].Value;
            Value2 = measurements[1].Value;
            Value1 = measurements[0].Value;
        }
        public void MoveListLeft()
        {
            if (measurements.Count > 1)
            {
                // Shift all elements to the left
                for (int i = 0; i < measurements.Count - 1; i++)
                {
                    measurements[i] = measurements[i + 1];
                }
            }
        }

        private string selectedEntity;
        private Color _selectedGoodColor;
        private Color _selectedBadColor;
        private ObservableCollection<Point> _dataPoints;
        private List<string> entityNames = ReactorCollection.GetAllTitles();
        private string time1;
        private string time2;
        private string time3;
        private string time4;
        private string time5;
        private double y1;
        private double y2;
        private double y3;
        private double y4;
        private double y5;
        private double y1t;
        private double y2t;
        private double y3t;
        private double y4t;
        private double y5t;
        private double value1;
        private double value2;
        private double value3;
        private double value4;
        private double value5;

        public double Value1
        {
            get { return value1; }
            set
            {
                if (!String.Equals(value1, value))
                    value1 = value;
                OnPropertyChanged(nameof(Value1));
            }
        }

        public double Value2
        {
            get { return value2; }
            set
            {
                if (!String.Equals(value2, value))
                    value2 = value;
                OnPropertyChanged(nameof(Value2));
            }
        }

        public double Value3
        {
            get { return value3; }
            set
            {
                if (!String.Equals(value3, value))
                    value3 = value;
                OnPropertyChanged(nameof(Value3));
            }
        }

        public double Value4
        {
            get { return value4; }
            set
            {
                if (!String.Equals(value4, value))
                    value4 = value;
                OnPropertyChanged(nameof(Value4));
            }
        }

        public double Value5
        {
            get { return value5; }
            set
            {
                if (!String.Equals(value5, value))
                    value5 = value;
                OnPropertyChanged(nameof(Value5));
            }
        }

        public double Y1
        {
            get { return y1; }
            set
            {
                if (!String.Equals(y1, value))
                    y1 = value;
                OnPropertyChanged(nameof(Y1));
            }
        }
        public double Y2
        {
            get { return y2; }
            set
            {
                if (!String.Equals(y2, value))
                    y2 = value;
                OnPropertyChanged(nameof(Y2));
            }
        }
        public double Y3
        {
            get { return y3; }
            set
            {
                if (!String.Equals(y3, value))
                    y3 = value;
                OnPropertyChanged(nameof(Y3));
            }
        }
        public double Y4
        {
            get { return y4; }
            set
            {
                if (!String.Equals(y4, value))
                    y4 = value;
                OnPropertyChanged(nameof(Y4));
            }
        }
        public double Y5
        {
            get { return y5; }
            set
            {
                if (!String.Equals(y5, value))
                    y5 = value;
                OnPropertyChanged(nameof(Y5));
            }
        }
        public double Y1t
        {
            get { return y1t; }
            set
            {
                if (!String.Equals(y1t, value))
                    y1t = value;
                OnPropertyChanged(nameof(Y1t));
            }
        }
        public double Y2t
        {
            get { return y2t; }
            set
            {
                if (!String.Equals(y2t, value))
                    y2t = value;
                OnPropertyChanged(nameof(Y2t));
            }
        }
        public double Y3t
        {
            get { return y3t; }
            set
            {
                if (!String.Equals(y3t, value))
                    y3t = value;
                OnPropertyChanged(nameof(Y3t));
            }
        }
        public double Y4t
        {
            get { return y4t; }
            set
            {
                if (!String.Equals(y4t, value))
                    y4t = value;
                OnPropertyChanged(nameof(Y4t));
            }
        }
        public double Y5t
        {
            get { return y5t; }
            set
            {
                if (!String.Equals(y5t, value))
                    y5t = value;
                OnPropertyChanged(nameof(Y5t));
            }
        }

        public string Time1
        {
            get { return time1; }
            set
            {
                if (!String.Equals(time1, value))
                    time1 = value;
                OnPropertyChanged(nameof(Time1));
            }
        } public string Time2
        {
            get { return time2; }
            set
            {
                if (!String.Equals(time2, value))
                    time2 = value;
                OnPropertyChanged(nameof(Time2));
            }
        } public string Time3
        {
            get { return time3; }
            set
            {
                if (!String.Equals(time3, value))
                    time3 = value;
                OnPropertyChanged(nameof(Time3));
            }
        } public string Time4
        {
            get { return time4; }
            set
            {
                if (!String.Equals(time4, value))
                    time4 = value;
                OnPropertyChanged(nameof(Time4));
            }
        } public string Time5
        {
            get { return time5; }
            set
            {
                if (!String.Equals(time5, value))
                    time5 = value;
                OnPropertyChanged(nameof(Time5));
            }
        }

        public ObservableCollection<Point> DataPoints
        {
            get { return _dataPoints; }
            set
            {
                _dataPoints = value;
                OnPropertyChanged(nameof(DataPoints));
            }
        }


        public List<string> EntityNames
        {
            get { return entityNames; }
            set
            {
                if (!String.Equals(entityNames, value))
                    entityNames = value;
                OnPropertyChanged(nameof(EntityNames));
            }
        }
        public string SelectedEntity
        {
            get { return selectedEntity; }
            set
            {
                if (!String.Equals(selectedEntity, value))
                    selectedEntity = value;
                measurements = NewEntityLoad(value);
                UpdateValues();
                OnPropertyChanged(nameof(selectedEntity));
            }
        }

        public Color SelectedGoodColor
        {
            get { return _selectedGoodColor; }
            set
            {
                _selectedGoodColor = value;
                OnPropertyChanged(nameof(SelectedGoodColor));
                ValueToColorConverter.AcceptableColor = _selectedGoodColor;
            }
        }
        public Color SelectedBadColor
        {
            get { return _selectedBadColor; }
            set
            {
                _selectedBadColor = value;
                OnPropertyChanged(nameof(SelectedBadColor));
                ValueToColorConverter.ErrorColor = _selectedBadColor;
            }
        }

        //Ucitavanje
        public List<Measurement> NewEntityLoad(string entityName)
        {
            string filePath = @"../../Log.txt";

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);
            List<Measurement> lastFiveMeasurements = new List<Measurement>();

            // Filter lines based on the specified entity name
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { ": Entity ", " - Value: " }, StringSplitOptions.None);
                if (String.Equals(parts[1], entityName))
                {
                    lastFiveMeasurements.Add(new Measurement(DateTime.Parse(parts[0]), Double.Parse(parts[2])));
                }
            }

            // Retrieve the last 5 measurements for the specific entity


            return lastFiveMeasurements;
        }
       
    }
}
