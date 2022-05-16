using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private ObservableCollection<string> backingProperty;

        public ObservableCollection<string> BoundProperty
        {
            get => backingProperty;
            set
            {
                backingProperty = value;
                PropChanged(nameof(BoundProperty));
            }
        }

        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void PropChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
