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
using DomainLayer;
using Business;

namespace UserInterfaceLayer.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : Window
    {
        public CustomersView()
        {

            InitializeComponent();
            LoadCustomerBoard();
        }
        public void LoadCustomerBoard()
        {
            foreach (Customer Cust in BusinessFacade.Instance.GetCustomerList())
            {
                DockPanel DockPanelForCustomer = new DockPanel();
                DockPanelForCustomer.Width = 700;
                DockPanelForCustomer.Height = 45;
                DockPanelForCustomer.HorizontalAlignment = HorizontalAlignment.Center;

                DockPanel DockPanelForButtons = new DockPanel();


                Label CustomerNameLabel = new Label();
                CustomerNameLabel.Content = Cust.Name;

                DockPanelForCustomer.Children.Add(CustomerNameLabel);
                CustomersStackPanel.Children.Add(DockPanelForCustomer);
                DockPanelForCustomer.Children.Add(DockPanelForButtons);


                Button BtnCustomerUpdate = new Button();
                Button BtnCustomerDelete = new Button();
                Button BtnExistingJobs = new Button();

                BtnCustomerUpdate.Content = "Rediger"; 
                BtnCustomerUpdate.Height = 20;
                BtnCustomerUpdate.Width = 50;
                BtnCustomerUpdate.HorizontalAlignment = HorizontalAlignment.Right;
                BtnCustomerUpdate.Margin = new Thickness(0, 0, 5, 0);
                BtnCustomerUpdate.DataContext = Cust;
                BtnCustomerUpdate.Click += BtnCustomerUpdate_click;

                BtnCustomerDelete.Content = "Slet";
                BtnCustomerDelete.Height = 20;
                BtnCustomerDelete.Width = 50;
                BtnCustomerDelete.HorizontalAlignment = HorizontalAlignment.Right;
                BtnCustomerDelete.Margin = new Thickness(0, 0, 5, 0);
                BtnCustomerDelete.DataContext = Cust;

                BtnExistingJobs.Content = "Tidligere opgaver";
                BtnExistingJobs.Height = 20;
                BtnExistingJobs.Width = 100;
                BtnExistingJobs.HorizontalAlignment = HorizontalAlignment.Right;
                BtnExistingJobs.Margin = new Thickness(0, 0, 5, 0);
                BtnExistingJobs.DataContext = Cust;

                DockPanelForButtons.Children.Add(BtnCustomerUpdate);
                DockPanelForButtons.Children.Add(BtnExistingJobs);
                DockPanelForButtons.Children.Add(BtnCustomerDelete);
                DockPanelForButtons.HorizontalAlignment = HorizontalAlignment.Right;
               

                DockPanelForCustomer.Margin = new Thickness(5,5,5,5);
                DockPanelForCustomer.Background = Brushes.WhiteSmoke;

                

            }

        }
        public void BtnCustomerUpdate_click(object sender, RoutedEventArgs e)
        {
            var CustomerClicked = ((Button)sender).DataContext;
            Customer cust = (Customer)CustomerClicked;
            CreateCustomerView CCV = new CreateCustomerView(cust.Name);
            CCV.ShowDialog();
            BusinessFacade.Instance.LoadCustomersToRepo();
            LoadCustomerBoard();
        }

        public void BtnExistingJob_click(object sender, RoutedEventArgs e)
        {
            var CustomerClicked = ((Button)sender).DataContext;
            Customer cust = (Customer)CustomerClicked;
            ExistingJobView EJV = new ExistingJobView(cust);
            EJV.ShowDialog();
        }
    }
}
