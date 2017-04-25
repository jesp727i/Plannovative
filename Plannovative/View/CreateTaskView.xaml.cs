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

namespace Plannovative.View
{
    /// <summary>
    /// Interaction logic for CreateTaskView.xaml
    /// </summary>
    public partial class CreateTaskView : Window
    {
        public CreateTaskView()
        {
            InitializeComponent();
        }

        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomerView CCV = new CreateCustomerView();
            CCV.OpenDialog();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
