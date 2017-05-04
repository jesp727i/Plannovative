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
        BusinessFacade BF;

        public CreateJobView()
        {
            BF = BusinessFacade.Instance;
            InitializeComponent();
            RefreshCustomer();
        }

        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomerView CCV = new CreateCustomerView();
            CCV.ShowDialog();
            RefreshCustomer();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
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
                MessageBox.Show("Opgaven " + '"' + TxtTaskName.Text + '"' +  " er oprettet");
                BF.SaveJob(TxtTaskName.Text, comboBoxCustomer.Text, TxtDescription.Text, CalenderDeadline.SelectedDate.Value, comboBoxPriceType.Text, double.Parse(TxtPrice.Text));
                this.Close();
            }

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            BF.CloseButtonClicked();
        }
        public void RefreshCustomer()
        {
            BF.LoadCustomersToRepo();
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

    }
}
