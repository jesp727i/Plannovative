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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserInterfaceLayer.View;
using System.Windows.Media.Animation;

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
            //"rengør" boardet så der er klar til at blive loadet opgaver ind på ny.
            splTodo.Children.Clear();
            splInProgress.Children.Clear();
            splDone.Children.Clear();
            BF.LoadJobToRepo();
            List<Job> jobListToShow = BF.GetJobList();

            //Får alle jobs frem på bordet, og giver dem farve alt efter hvor lang
            //tid der er til deadline
            foreach (var job in jobListToShow)
            {
               
                StackPanel newStackPanel = new StackPanel();
                DateTime today = DateTime.Today;
                double daysToDeadLine = (job.Deadline - today).TotalDays;
                newStackPanel.Width = 300;
                newStackPanel.Height = 100;
                
                

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

                //Bestemmer hvordan stacpanels skal se ud i de 3 kolonner
                Border border = new Border();
                border.CornerRadius = new CornerRadius(35);
                newStackPanel.Children.Add(border);
                newStackPanel.Margin = new Thickness(5);
                newStackPanel.Orientation = Orientation.Vertical;
                newStackPanel.MouseDown += MouseDownChild;
                

                //instantiering af labels og knap en en "opgave" har på boardet.
                Label nameLabel = new Label();
                Label custLabel = new Label();
                Label deadlineLabel = new Label();
                Label idLabel = new Label();
                DockPanel CustAndDead = new DockPanel();
                Button forwardButton = new Button();
                Button backButton = new Button();
                
               
                //kode der sørger for at der ikke er en frem-knap" hvis opgaven er færdig
                if (job.Position == 1)
                {
                    splTodo.Children.Add(newStackPanel);
                    newStackPanel.Children.Add(forwardButton);
                    forwardButton.Margin = new Thickness(5, 5, 5, 5);
                  
                }
                else if (job.Position == 2)
                {
                    DockPanel backAndForward = new DockPanel();
                    backAndForward.Children.Add(backButton);
                    backAndForward.Children.Add(forwardButton);
                    splInProgress.Children.Add(newStackPanel);
                    newStackPanel.Children.Add(backAndForward);
                    
                    forwardButton.Margin = new Thickness(5, 5, 5, 5);
                    backButton.Margin = new Thickness(5, 5, 5, 5);
                }
                else if (job.Position == 3)
                {
                    splDone.Children.Add(newStackPanel);
                    CustAndDead.Margin = new Thickness(0, 20, 0, 0);
                }


                //kundenavn på opgaven
                custLabel.HorizontalAlignment = HorizontalAlignment.Left;
                custLabel.Content = job.Customer.Name;

                //Navnet på opgaven
                nameLabel.FontFamily = new FontFamily("Impact");
                nameLabel.HorizontalAlignment = HorizontalAlignment.Left;
                nameLabel.FontSize = 20;
                nameLabel.Content = job.Name;

                //DeadLine på opgaven
                deadlineLabel.FontStyle = FontStyles.Italic;
                deadlineLabel.FontFamily = new FontFamily("Delecious");
                deadlineLabel.FontSize = 10;
                deadlineLabel.HorizontalAlignment = HorizontalAlignment.Right;

                //"Tilbage-knappen"
                backButton.Content = "<";
                backButton.Click += BtnMoveJobBack_Click;
                backButton.DataContext = job;
                backButton.HorizontalAlignment = HorizontalAlignment.Left;

                //"Frem-knappen"
                forwardButton.Content = ">";
                forwardButton.Click += BtnMoveJob_Click;
                forwardButton.DataContext = job;
                forwardButton.HorizontalAlignment = HorizontalAlignment.Right;

                // Hvis der ingen deadline er på opgaven.
                if (job.Deadline.ToString() == DateTime.MaxValue.ToString())
                {
                    deadlineLabel.Content = "Ingen deadline";
                }
                else
                {
                    deadlineLabel.Content = job.Deadline.ToString("dd-MM-yyyy");
                }     
                        
                //tilføjer alle labels til et jobs stackpanel.
                newStackPanel.Children.Add(nameLabel);
                CustAndDead.Children.Add(custLabel);
                CustAndDead.Children.Add(deadlineLabel);
                newStackPanel.Children.Add(idLabel);
                newStackPanel.DataContext = job;
                newStackPanel.Children.Add(CustAndDead);
                
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
        private void BtnMoveJob_Click(object sender, RoutedEventArgs e)
        {
            var jobClicked = ((Button)sender).DataContext;
            Job job = (Job)jobClicked;
            job.Position = job.Position + 1;
            BF.MoveJob(job);
            LoadBoard();
        }

        private void BtnMoveJobBack_Click(object sender, RoutedEventArgs e)
        {
            var jobClicked = ((Button)sender).DataContext;
            Job job = (Job)jobClicked;
            job.Position = job.Position - 1;
            BF.MoveJob(job);
            LoadBoard();
        }


    }
    
}
