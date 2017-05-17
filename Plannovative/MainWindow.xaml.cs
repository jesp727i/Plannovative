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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserInterfaceLayer.View;

namespace UserInterfaceLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BusinessFacade BF;
        public MainWindow()
        {
            InitializeComponent();
            BF = BusinessFacade.Instance;
            BF.LoadCustomersToRepo();
            LoadBoard();
        }
        
        private void BtnCreateJob_Click(object sender, RoutedEventArgs e)
        {
            CreateJobView CJV = new CreateJobView();
            CJV.ShowDialog();
            LoadBoard();
        }     
        private void LoadBoard()
        {
            splTodo.Children.Clear();
            splInProgress.Children.Clear();
            splDone.Children.Clear();
            BF.LoadJobToRepo();
            List<Job> jobListToShow = BF.GetJobList();

            foreach (var job in jobListToShow)
            {

                StackPanel newStackPanel = new StackPanel();
                DateTime today = DateTime.Today;
                double daysToDeadLine = (job.Deadline - today).TotalDays;
                newStackPanel.Width = 300;
                newStackPanel.Height = 80;
                if (daysToDeadLine < 14)
                {
                    newStackPanel.Background = Brushes.OrangeRed;
                }
                else if (daysToDeadLine < 28)
                {
                    newStackPanel.Background = Brushes.Gold;
                }
                else
                {
                    newStackPanel.Background = Brushes.GreenYellow;
                }


                newStackPanel.Margin = new Thickness(5);
                newStackPanel.Orientation = Orientation.Vertical;
                newStackPanel.MouseDown += MouseDownChild;

                Label nameLabel = new Label();
                Label custLabel = new Label();
                Label deadlineLabel = new Label();
                Label idLabel = new Label();
                nameLabel.Content = job.Name;
                custLabel.Content = job.Customer.Name;

                if (job.Deadline == DateTime.MaxValue)
                {
                    deadlineLabel.Content = "Ingen deadline";
                }
                else
                {
                    deadlineLabel.Content = job.Deadline;
                }
                if (job.Position == 1)
                {
                    splTodo.Children.Add(newStackPanel);
                }
                else if (job.Position == 2)
                {
                    splInProgress.Children.Add(newStackPanel);
                }
                else if (job.Position == 3)
                {
                    splDone.Children.Add(newStackPanel);
                }
                Button b = new Button();
                b.Content = ">";
                newStackPanel.Children.Add(nameLabel);
                newStackPanel.Children.Add(custLabel);
                newStackPanel.Children.Add(deadlineLabel);
                newStackPanel.Children.Add(idLabel);
                newStackPanel.Children.Add(b);
                newStackPanel.DataContext = job;
            }
        }
        
        private void BtnShowCustomers_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MouseDownChild(object sender, MouseButtonEventArgs e)
        {
            var jobClicked = ((StackPanel)sender).DataContext;

            ShowJobView SJV = new ShowJobView(jobClicked);
            SJV.ShowDialog();
            LoadBoard();

        }
    }
    
}
