using Business;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserInterfaceLayer.View
{
    /// <summary>
    /// Interaction logic for CreateCustomerView.xaml
    /// </summary>
    public partial class CreateCustomerView : Window
    {   
        bool update = false;

        public CreateCustomerView()
        {
            InitializeComponent();
        }
        public CreateCustomerView(string customerName)
        {
            InitializeComponent();

            TxtPhone.IsEnabled = false;
            Customer cust = BusinessFacade.Instance.GetCustomerByName(customerName);
            TxtName.Text = cust.Name;
            TxtEmail.Text = cust.Email;
            TxtPhone.Text = cust.Phone;
            TxtAddress.Text = cust.Address;
            TxtZip.Text = cust.Zip;
            TxtCity.Text = cust.City;
            TxtCVR.Text = cust.CVR;
            update = true;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                BusinessFacade.Instance.UpdateCustomer(TxtName.Text, TxtEmail.Text, TxtPhone.Text, TxtAddress.Text, TxtZip.Text, TxtCity.Text, TxtCity.Text);
                MessageBox.Show(TxtName.Text + " er nu redigeret");
            }
            else
            {
                BusinessFacade.Instance.SaveCustomer(TxtName.Text, TxtEmail.Text, TxtPhone.Text, TxtAddress.Text, TxtZip.Text, TxtCity.Text, TxtCity.Text);
                MessageBox.Show(TxtName.Text + " er nu tilføjet");

            }
            
            this.Close();
        }
    }
}
