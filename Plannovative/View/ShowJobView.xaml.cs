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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ShowJobView : Window
    {
        Job job;
        BusinessFacade BF;
        
        public ShowJobView(object currentJob)
        {
            InitializeComponent();
            job = (Job)currentJob;
            BF = BusinessFacade.Instance;
            setJobToView();
        }
        private void setJobToView()
        {
            comboBoxEndTime.IsEnabled = false;
            JobLabel.Content = job.Name;
            CustomerLabel.Content = job.Customer.Name;
            DeadlineLabel.Content = job.Deadline.ToString("dd-MM-yyyy");
            if (job.Deadline.ToString() == DateTime.MaxValue.ToString())
            {
                DeadlineLabel.Content = "Ingen deadline";
            }
            TimeUsedtLabel.Content = job.TimeUsed + " Timer";
            if (job.PriceType)
            {
                PriceLabel.Content = job.Price.ToString() + " kr.";
            }
            else
            {
                PriceLabel.Content = job.Price.ToString() + " kr/time.";
            }
            
            DescriptionLabel.Text = job.Description;
            // kodestykke der fylder comboboxstart, så man kan vælge tidspunkter, når man skal tilføje tid.
            int i = 0;
            int t = 2;
            string k = "0";
            while (i < 24)
            {
                if (i == 10)
                {
                    k = "";
                }
                if (t % 2 == 0)
                {
                    comboBoxStartTime.Items.Add(k + i + ":00");
                }
                else
                {
                    comboBoxStartTime.Items.Add(k + i + ":30");
                    i++;
                }
                t++;
            }

        }

        private void BtnAddTime_Click(object sender, RoutedEventArgs e)
        {
            if (CalenderDate.SelectedDate == null)
            {
                CalenderDate.SelectedDate = CalenderDate.DisplayDate;
            }
            BF.SaveTimeAndDate(TimeSpan.Parse(comboBoxStartTime.Text), TimeSpan.Parse(comboBoxEndTime.Text),
                CalenderDate.SelectedDate.Value, job);
            MessageBox.Show("Nye arbejdstider på opgaven tilføjet!\n" + "Dato: " + CalenderDate.SelectedDate.Value.Day +"/" + CalenderDate.SelectedDate.Value.Month + "-" + CalenderDate.SelectedDate.Value.Year + "\n Fra " + comboBoxStartTime.Text + " Til " + comboBoxEndTime.Text);
            TimeUsedtLabel.Content = job.TimeUsed + " Timer";
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnUpdateJob_Click(object sender, RoutedEventArgs e)
        {
            CreateJobView CJW = new CreateJobView(job);
            CJW.ShowDialog();
            setJobToView();
        }

        private void comboBoxStartTime_DropDownClosed(object sender, EventArgs e)
        {
            comboBoxEndTime.Items.Clear();
            comboBoxEndTime.IsEnabled = true;
            int i = 0;
            int t = 2;
            string k = "0";
            string result;
            bool startResult = false;
            while (i < 24)
            {

                if (i == 10)
                {
                    k = "";
                }
                if (t % 2 == 0)
                {
                    result = k + i + ":00";
                }
                else
                {
                    result = k + i + ":30";
                    i++;
                }
                if (startResult)
                {
                    comboBoxEndTime.Items.Add(result);
                } else if (comboBoxStartTime.Text == result)
                {
                    startResult = true;
                }
                t++;
            }
        }
    }
}
