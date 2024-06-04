using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace NetworkService.ViewModel
{
    public class NetworkDisplayViewModel : BindableBase
    {
        public NetworkDisplayViewModel()
        {
            copyCollection = new ObservableCollection<ReactorTemp>(ReactorCollection.Entities);
            ReactorCollection.EntitiesChanged += ReactorCollection_EntitiesChanged;

            ReactorTempsView = CollectionViewSource.GetDefaultView(copyCollection);
            ReactorTempsView.GroupDescriptions.Add(new PropertyGroupDescription("TypeName"));
        }

        public ICollectionView ReactorTempsView { get; set; }
        public ObservableCollection<ReactorTemp> copyCollection { get; }

        private void ReactorCollection_EntitiesChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var tempCollection = new ObservableCollection<ReactorTemp>();
                foreach (var entity in ReactorCollection.Entities)
                {
                    tempCollection.Add(entity);
                    entity.PropertyChanged -= Entity_PropertyChanged; // Ensure not to subscribe multiple times
                    entity.PropertyChanged += Entity_PropertyChanged; // Subscribe to PropertyChanged event of each entity
                }

                // Update copyCollection after enumeration completes
                copyCollection.Clear();
                foreach (var entity in tempCollection)
                {
                    copyCollection.Add(entity);
                }
            });
        }
        private void Entity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // If any property of a ReactorTemp object changes, update copyCollection
            var changedEntity = (ReactorTemp)sender;
            if (copyCollection.Contains(changedEntity))
            {
                // Remove and re-add to ensure the correct order
                copyCollection.Remove(changedEntity);
                copyCollection.Add(changedEntity);
            }
        }

        public void RemoveEntityFromCopyCollection(ReactorTemp entity)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (copyCollection.Contains(entity))
                {
                    copyCollection.Remove(entity);
                }
            });
        }
        //DragnDrop


    }
}
