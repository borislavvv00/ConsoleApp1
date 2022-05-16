using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace WpfExample
{
    public class NamesList : INotifyPropertyChanged
    {
        AddCommand addCommand = new AddCommand();

        public AddCommand AddCommand => addCommand;

        RemoveCommand removeCommand = new RemoveCommand();

        public RemoveCommand RemoveCommand => removeCommand;

        string firstName = "";
        string lastName = "";
        string selectedName = "";

        public NamesList()
        {
            Names = new ObservableCollection<string>();
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if(firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public string SelectedName
        {
            get => selectedName;
            set
            {
                if (selectedName != value)
                {
                    selectedName = value;
                    OnPropertyChanged(nameof(SelectedName));
                }
            }
        }

        public ObservableCollection<string> Names { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
