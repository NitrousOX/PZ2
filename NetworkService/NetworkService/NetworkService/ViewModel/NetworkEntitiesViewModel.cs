using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace NetworkService.ViewModel
{
    public class NetworkEntitiesViewModel : BindableBase
    {

        public NetworkEntitiesViewModel()
        {
            AddEntityCommand = new MyICommand(AddEntity);
            DeleteEntityCommand = new MyICommand(DeleteEntity, CanDeleteEntity);
            ApplyFilterCommand = new MyICommand(ApplyFilter);
            ClearFilterCommand = new MyICommand(ClearFilter);

            FilteredView = CollectionViewSource.GetDefaultView(ReactorCollection.Entities);
            
            IsLessThanChecked = true;
            GenerateNextId();
        }

        private void GenerateNextId()
        {
            List<int> all_id = ReactorCollection.GetAllId();
            if (all_id == null)
                AddIdText = 0.ToString();

            int nextId = 0;
            while (all_id.Contains(nextId))
            {
                nextId++;
            }
            AddIdText = nextId.ToString();
        }

        private bool FilterCollection(object obj)
        {

           if(obj is ReactorTemp entity)
            {
                if (entity.Type.Name == Filterselectedtype || String.IsNullOrEmpty(Filterselectedtype))
                {
                    if (String.IsNullOrEmpty(FilterValue))
                        return true;
                    if (IsLessThanChecked)
                    {
                        if (entity.Id < Double.Parse(FilterValue))
                            return true;
                    }
                    else if (IsGreaterThanChecked)
                    {
                        if (entity.Id > Double.Parse(FilterValue))
                            return true;
                    }
                    else
                    {
                        if (entity.Id == Double.Parse(FilterValue))
                            return true;
                    }
                }
            }
           return false;
        }

        private ReactorTemp selectedEntity;
        public ReactorTemp SelectedEntity {
            get
            {
                return selectedEntity;
            }

            set
            {
                if (selectedEntity != value)
                {
                    selectedEntity = value;
                    OnPropertyChanged(nameof(SelectedEntity));
                    DeleteEntityCommand.RaiseCanExecuteChanged();
                }
            }
        }
        //Observable collectionView
        public ICollectionView FilteredView { get; }

        // Properties for filtering

        private bool _isLessThanChecked;
        private bool _isGreaterThanChecked;
        private bool _isEqualChecked;
        private string _filterValue;
        private string _addIdText;
        private string _addTitleText;


        //ComboBox
        private List<string> types = new List<string>() { "RTD", "ThermoCouple" };
        private string filterselectedtype;
        private string addselectedtype;
        public string Filterselectedtype
        {
            get { return filterselectedtype; }
            set
            {
                if (!String.Equals(filterselectedtype, value))
                    filterselectedtype = value;
                OnPropertyChanged(nameof(Filterselectedtype));
            }
        }

        public string Addselectedtype
        {
            get { return addselectedtype; }
            set
            {
                if (!String.Equals(addselectedtype, value))
                    addselectedtype = value;
                OnPropertyChanged(nameof(Addselectedtype));
            }
        }


        public List<string> Types {
            get { return types; }
            set
            {
                if (types != value)
                    types = value;
                OnPropertyChanged(nameof(Types));
            }
        }

        //ostalo
        public bool IsLessThanChecked {
            get { return _isLessThanChecked; }
            set
            {
                if (_isLessThanChecked != value)
                    _isLessThanChecked = value;
                OnPropertyChanged(nameof(IsLessThanChecked));
            }
        }
        public bool IsGreaterThanChecked {
            get { return _isGreaterThanChecked; }
            set
            {
                if (_isGreaterThanChecked != value)
                    _isGreaterThanChecked = value;
                OnPropertyChanged(nameof(IsGreaterThanChecked));
            }
        }
        public bool IsEqualChecked {
            get { return _isEqualChecked; }
            set
            {
                if (_isEqualChecked != value)
                    _isEqualChecked = value;
                OnPropertyChanged(nameof(IsEqualChecked));
            }
        }
        public string FilterValue {
            get { return _filterValue; }
            set
            {
                if (_filterValue != value)
                    _filterValue = value;
                OnPropertyChanged(nameof(FilterValue));
            }
        }
        public string AddIdText
        {
            get { return _addIdText; }
            set
            {
                if (_addIdText != value)
                    _addIdText = value;
                OnPropertyChanged(nameof(AddIdText));
            }
        }
        public string AddTitleText
        {
            get { return _addTitleText; }
            set
            {
                if (_addTitleText != value)
                    _addTitleText = value;
                OnPropertyChanged(nameof(AddTitleText));
            }
        }

        public MyICommand AddEntityCommand { get; }
        public MyICommand DeleteEntityCommand { get; }
        public MyICommand ApplyFilterCommand { get; }
        public MyICommand ClearFilterCommand { get; }

        private void AddEntity()
        {
            if (addselectedtype == null || String.IsNullOrEmpty(AddTitleText))
                return;
            Random rand = new Random();
            if (addselectedtype == "RTD")
                ReactorCollection.Entities.Add(new ReactorTemp(Int32.Parse(AddIdText), AddTitleText, rand.Next(250, 351), ReactorCollection.ThermoTypes["RTD"]));
            else
                ReactorCollection.Entities.Add(new ReactorTemp(Int32.Parse(AddIdText), AddTitleText, rand.Next(250, 351), ReactorCollection.ThermoTypes["TC"]));
            GenerateNextId();

            MessageBox.Show("Successfully added new entitty!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void DeleteEntity()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this entity?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.OK)
            {
                ReactorCollection.Entities.Remove(selectedEntity);
                GenerateNextId();
            }
            
        }

        private bool CanDeleteEntity()
        {
            return SelectedEntity != null;
        }

        private void ApplyFilter()
        {
            FilteredView.Filter = FilterCollection;
            FilteredView.Refresh();
        }

        private void ClearFilter()
        {
            Filterselectedtype = null;
            FilterValue = String.Empty;
            FilteredView.Filter = null; 
        }


    }
}
