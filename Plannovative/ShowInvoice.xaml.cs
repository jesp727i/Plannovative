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
        BusinessFacade BF;

        public ShowInvoice(Job job)
        {
            InitializeComponent();
           currentJob = job;
            BF = BusinessFacade.Instance;
            LoadInvoices();

        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

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


            //Til hver linje i fakturaen
            foreach (WorkTime times in currentJob.WorkTimeList)
            {
                StackPanel invoiceSpl = new StackPanel();
                invoiceSpl.Margin = new Thickness(0, 0, 0, 5);              
                                                
                Label workDate = new Label();
                Label calculatedTimeADayLabel = new Label();
                DockPanel workTimeInfo = new DockPanel();
                Label unitType = new Label();
                Label Price = new Label();
                Label numbersTimesPrice = new Label();



                workDate.Content = times.WorkDate;
                calculatedTimeADayLabel.Content = times.CalculatedTimeStartEnd() ;
                unitType.Content = currentJob.PriceType;
                if (currentJob.PriceType)
                {
                    unitType.Content = "Fast";
                }
                else
                {
                    unitType.Content = "Timer";
                }
                Price.Content = currentJob.Price;
                

                workDate.HorizontalAlignment = HorizontalAlignment.Left;
                workDate.Margin = new Thickness(0, 0, 30, 0);
                calculatedTimeADayLabel.HorizontalAlignment = HorizontalAlignment.Left;
                calculatedTimeADayLabel.Margin = new Thickness(0, 0, 30, 0);
                unitType.Margin = new Thickness(0, 0, 60, 0);
                numbersTimesPrice.HorizontalAlignment = HorizontalAlignment.Right;

                // numbersTimesPrice.Content = times.CalculatedTimeStartEnd();

                numbersTimesPrice.Content = times.CalculatedTimeStartEnd() * currentJob.Price;



                




                workTimeInfo.Children.Add(workDate);
                workTimeInfo.Children.Add(calculatedTimeADayLabel);
                workTimeInfo.Children.Add(unitType);
                workTimeInfo.Children.Add(Price);
                workTimeInfo.Children.Add(numbersTimesPrice);

                invoiceSpl.Children.Add(workTimeInfo);
                spInvoice.Children.Add(invoiceSpl);
            }


            //CustomerHeader (til venstre i toppen)

            StackPanel customerDock = new StackPanel();
            customerDock.Orientation = Orientation.Vertical;
            Label faktura = new Label();
            faktura.Content = "FAKTURA";
            faktura.FontSize = 16;

            Label customerName = new Label();
            customerName.Content = currentJob.Customer.Name;
            customerName.FontWeight = FontWeights.Bold;
            Label CustomerAdress = new Label();
            CustomerAdress.Content = currentJob.Customer.Address;
            Label zipAndCity = new Label();
            zipAndCity.Content = currentJob.Customer.Zip + " " + currentJob.Customer.City;

            customerDock.Children.Add(customerName);
            customerDock.Children.Add(CustomerAdress);
            customerDock.Children.Add(zipAndCity);

            customerHeader.Children.Add(customerDock);

            // MOMS og samlet pris på opgaven

            StackPanel totalPrice = new StackPanel();
            totalPrice.Orientation = Orientation.Vertical;

            Label withoutVAT = new Label();
            withoutVAT.Content = "Subtotal uden moms:  " + (currentJob.Price * currentJob.TimeUsed);

            Label onlyVAT = new Label();
            onlyVAT.Content = "MOMS 25% af " + (currentJob.Price * currentJob.TimeUsed) + "     " + (currentJob.Price * currentJob.TimeUsed)/4 + "   // Momsen";

            Label withVAT = new Label();
            withVAT.Content = "Total DKK " + (currentJob.Price * currentJob.TimeUsed) + "//Momsen" ;


            totalPrice.Children.Add(withoutVAT);
            totalPrice.Children.Add(onlyVAT);
            totalPrice.Children.Add(withVAT);

            VATAndTotalPrice.Children.Add(totalPrice);


        }




    }
}
