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
using UserInterfaceLayer.ViewModel;

namespace UserInterfaceLayer.View
{
    /// <summary>
    /// Interaction logic for CreateTaskView.xaml
    /// </summary>
    public partial class CreateJobView : Window
    {

        CreateJobViewModel CJVM;
        public CreateJobView()
        {
            InitializeComponent();
            CJVM = new CreateJobViewModel();
            comboBoxCustomer.ItemsSource = CJVM.GetCostumerList();
        }

        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomerView CCV = new CreateCustomerView();
            CCV.ShowDialog();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TxtTaskName.Text + comboBoxCustomer.Text + TxtDescription.Text + CalenderDeadline.SelectedDate + comboBoxPriceType.Text + TxtPrice.Text);
            //CJVM.NewJob(TxtTaskName, comboBoxCustomer, TxtDescription, CalenderDeadline, comboBoxPriceType, TxtPrice);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
