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
    /// Interaction logic for ExistingJobView.xaml
    /// </summary>
    public partial class ExistingJobView : Window
    {
        public ExistingJobView()
        {
            InitializeComponent();
        }


        public ExistingJobView(Customer cust)
        {
           InitializeComponent();
           List<Job> Joblist =  BusinessFacade.Instance.GetJobsForCustomer(cust);
           LoadJobListBoard(Joblist);
        }

        private void LoadJobListBoard(List<Job> joblist)
        {

            foreach (Job job in joblist)
            {
                DockPanel DockPanelForJobs = new DockPanel();

                Label JobNameLabel = new Label();
                JobNameLabel.Content = job.Name;



                JobsStackPanel.Children.Add(DockPanelForJobs);
                
                DockPanelForJobs.Children.Add(JobNameLabel);
                DockPanelForJobs.Background = Brushes.WhiteSmoke;
                DockPanelForJobs.Margin = new Thickness(5,3,5,3);
                DockPanelForJobs.Width = 254;
                DockPanelForJobs.DataContext = job;
                DockPanelForJobs.MouseLeftButtonDown += ExistingJob_click;

            }
        }
        public void ExistingJob_click(object sender, RoutedEventArgs e)
        {
            var JobsClicked = ((DockPanel)sender).DataContext;
            Job job = (Job)JobsClicked;
            ShowJobView EJV = new ShowJobView(job);
            EJV.ShowDialog();
        }


    }
}
