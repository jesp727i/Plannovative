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

namespace Plannovative
{
    /// <summary>
    /// Interaction logic for ShowInvoice.xaml
    /// </summary>
    public partial class ShowInvoice : Window
    {
        
        Job currentJob;

        public ShowInvoice(Job job)
        {
            InitializeComponent();
           currentJob = job;
            LoadInvoices();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveInovice_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void LoadInvoices()
        {
            spInvoice.Children.Clear();

            foreach (WorkTime times in currentJob.WorkTimeList)
            {
                StackPanel invoiceSpl = new StackPanel();
                invoiceSpl.Background = Brushes.Aqua;


                Label startTime = new Label();
                Label endTime = new Label();
                Label workDate = new Label();
                Label calculatedTimeADay = new Label();
                DockPanel workStartEndCalculatedTimeADay = new DockPanel();


                calculatedTimeADay.Content = times.EndTime - times.StartTime;
                startTime.Content = times.StartTime;
                endTime.Content = times.EndTime;
                workDate.Content = times.WorkDate;


                workDate.HorizontalAlignment = HorizontalAlignment.Left;
                workDate.Margin = new Thickness(0, 0, 30, 0);
                startTime.HorizontalAlignment = HorizontalAlignment.Center;
                startTime.Margin = new Thickness(0, 0, 25, 0);
                endTime.Margin = new Thickness(75, 0, 0, 0);
                calculatedTimeADay.HorizontalAlignment = HorizontalAlignment.Right;


                workStartEndCalculatedTimeADay.Children.Add(workDate);
                workStartEndCalculatedTimeADay.Children.Add(startTime);
                workStartEndCalculatedTimeADay.Children.Add(endTime);
                workStartEndCalculatedTimeADay.Children.Add(calculatedTimeADay);

                invoiceSpl.Children.Add(workStartEndCalculatedTimeADay);
                spInvoice.Children.Add(invoiceSpl);
            }

            //Logo Header (til højre i toppen)
            StackPanel HeaderDock = new StackPanel();
            HeaderDock.Orientation = Orientation.Vertical;
            Label sabrinaLogo = new Label();
            sabrinaLogo.FontSize = 25;
            sabrinaLogo.Content = "SABRINA PAULSEN";
            Label sabrinaLogo2 = new Label();
            sabrinaLogo2.Content = "Entrepreneur og designmanager";
                         
            HeaderDock.Children.Add(sabrinaLogo);
            HeaderDock.Children.Add(sabrinaLogo2);
            
            HeaderInovoice.Children.Add(HeaderDock);

            //CustomerHeader (til venstre i toppen)

            StackPanel customerDock = new StackPanel();
            customerDock.Orientation = Orientation.Vertical;
            Label faktura = new Label();
            faktura.Content = "FAKTURA";
            faktura.FontSize = 16;

            Label customerName = new Label();
            customerName.Content = currentJob.Customer.Name;
            customerName.FontFamily = new FontFamily("Italic");
            Label CustomerAdress = new Label();
            CustomerAdress.Content = currentJob.Customer.Address;
            Label zipAndCity = new Label();
            zipAndCity.Content = currentJob.Customer.Zip + " " + currentJob.Customer.City;

            customerDock.Children.Add(customerName);
            customerDock.Children.Add(CustomerAdress);
            customerDock.Children.Add(zipAndCity);

            customerHeader.Children.Add(customerDock);
            

        

        




            
            
            
           
            
           
        }




    }
}
