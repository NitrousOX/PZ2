using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NetworkService.ViewModel
{
    public class MeasurmentGraphViewModel : BindableBase
    {
        public MeasurmentGraphViewModel()
        {
            SelectedBadColor = ValueToColorConverter.ErrorColor;
            SelectedGoodColor = ValueToColorConverter.AcceptableColor;
        }

        private List<string> entityNames = ReactorCollection.GetAllTitles();
        private string selectedEntity;
        private Color _selectedGoodColor;
        private Color _selectedBadColor;

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


        //Komande

    }
}
