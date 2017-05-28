﻿using System;
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
using Business;
using DomainLayer;

namespace UserInterfaceLayer.View
{
    /// <summary>
    /// Interaction logic for CreateTaskView.xaml
    /// </summary>
    public partial class CreateJobView : Window
    {
        bool update = false;
        int Position;
        int JobId;
        BusinessFacade BF;
        public CreateJobView()
        {
            BF = BusinessFacade.Instance;
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(WindowClosingTrue);
            RefreshCustomer();
            this.BtnSave.IsEnabled = false;
        }
        public CreateJobView(Job job) 
        {
            BF = BusinessFacade.Instance;
            this.Closing += new System.ComponentModel.CancelEventHandler(WindowClosingTrue);
            InitializeComponent();
            update = true;
            TxtDescription.Text = job.Description;
            TxtPrice.Text = job.Price.ToString();
            CalenderDeadline.SelectedDate = job.Deadline;
            RefreshCustomer();
            if (!job.PriceType)
            {
                comboBoxPriceType.SelectedIndex = 1;
            }
            Position = job.Position;
            JobId = job.JobID;
            TxtTaskName.Text = job.Name;
        }

        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomerView CCV = new CreateCustomerView();
            CCV.ShowDialog();
            BF.LoadCustomersToRepo();
            RefreshCustomer();

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Closing += new System.ComponentModel.CancelEventHandler(WindowClosingFalse);
            if (CalenderDeadline.SelectedDate == null)
            {
                CalenderDeadline.SelectedDate = DateTime.MaxValue;
            }


            if (TxtTaskName.Text =="" || comboBoxCustomer.Text == "")
            {
                MessageBox.Show("En opgave skal have både Opgave navn og en Kunde");

            }
            else
            {
                if (!update)
                {
                    MessageBox.Show("Opgaven " + '"' + TxtTaskName.Text + '"' + " er oprettet");
                    BF.SaveJob(TxtTaskName.Text, comboBoxCustomer.Text, TxtDescription.Text, CalenderDeadline.SelectedDate.Value, comboBoxPriceType.Text, double.Parse(TxtPrice.Text), 1);
                }
                else
                {
                    BF.UpdateJob(JobId, TxtTaskName.Text, comboBoxCustomer.Text, TxtDescription.Text, CalenderDeadline.SelectedDate.Value, comboBoxPriceType.Text, double.Parse(TxtPrice.Text));
                }
               this.Close();
            }

        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Closing += new System.ComponentModel.CancelEventHandler(WindowClosingFalse);
            this.Close();
        }
        public void RefreshCustomer()
        {
            
            this.comboBoxCustomer.ItemsSource = BF.GetCustomerNames();

        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (comboBoxCustomer.Text == "")
            {
                MessageBox.Show("En kunde skal vælges, før redigering");

            }
            else
            {
                CreateCustomerView CCV = new CreateCustomerView(comboBoxCustomer.Text);
                CCV.ShowDialog();
                RefreshCustomer();
            }

        }
        private void comboBoxCustomer_DropDownClosed(object sender, EventArgs e)
        {
            UpdateUserInterface();
        }
        private void TxtTaskName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUserInterface();
        }
        private void UpdateUserInterface()
        {
            this.BtnSave.IsEnabled = !string.IsNullOrWhiteSpace(this.comboBoxCustomer.Text) &&
                                    !string.IsNullOrWhiteSpace(this.TxtTaskName.Text);
        }
        void WindowClosingTrue(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
        void WindowClosingFalse(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }


    }
}
