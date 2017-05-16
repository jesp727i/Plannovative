﻿using Business;
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
        
        public ShowJobView(object currentJob)
        {
            InitializeComponent();
            job = (Job)currentJob;
            setJobToView();
        }
        private void setJobToView()
        {
            JobLabel.Content = job.Name;
            CustomerLabel.Content = job.Customer.Name;
            DeadlineLabel.Content = job.Deadline.ToString();
            TimeUsedtLabel.Content = job.TimeUsed;
            if (job.PriceType)
            {
                PriceLabel.Content = job.Price.ToString() + " kr.";
            }
            else
            {
                PriceLabel.Content = job.Price.ToString() + " kr/time.";
            }
            
            DescriptionLabel.Text = job.Description;
        }

        private void BtnAddTime_Click(object sender, RoutedEventArgs e)
        {
            WorkTime workTime = new WorkTime(TimeSpan.Parse(comboBoxStartTime.Text),TimeSpan.Parse(comboBoxEndTime.Text),
                CalenderDate.SelectedDate.Value,job.JobID);
            job.AddToWorkTimeList(workTime);
            MessageBox.Show("Nye arbejdstider på opgaven tilføjet!\n" + "Dato: " + CalenderDate.SelectedDate.Value.Day +"/" + CalenderDate.SelectedDate.Value.Month + "-" + CalenderDate.SelectedDate.Value.Year + "\n Fra " + comboBoxStartTime.Text + " Til " + comboBoxEndTime.Text);

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnUpdateJob_Click(object sender, RoutedEventArgs e)
        {
            var jobObjekt = job;
            CreateJobView SJW = new CreateJobView(jobObjekt);
            SJW.ShowDialog();
        }
    }
}
