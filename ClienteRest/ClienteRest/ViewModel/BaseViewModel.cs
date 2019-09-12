using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ClienteRest.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(String propertyName = "")
        {
            if (propertyName!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
