using Plannovative.ViewModel;
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
        CreateCustomerViewModel CCVM;

        public CreateCustomerView()
        {
            InitializeComponent();
            CCVM = new CreateCustomerViewModel();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            CCVM.NewCustomer(TxtName.Text, TxtEmail.Text, TxtPhone.Text, TxtAddress.Text, TxtZip.Text, TxtCity.Text, TxtCity.Text);
            MessageBox.Show(TxtName.Text + " er nu tilføjet!");
            this.Close();
        }
    }
}
