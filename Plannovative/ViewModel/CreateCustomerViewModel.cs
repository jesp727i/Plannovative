using Business;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterfaceLayer;

namespace UserInterfaceLayer.ViewModel
{
    class CreateCustomerViewModel : INotifyPropertyChanged
    {
        BusinessFacade BF;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _Name;
        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        public int MyProperty { get; set; }


        public CreateCustomerViewModel()
        {
            BF = new BusinessFacade();
          
        }

        internal void NewCustomer(string name, string Email, string phone, string address, string zip, string city, string cvr)
        {
          BF.SaveCustomer(Name, Email, phone, address, zip, city, cvr);
          
            
        }
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
