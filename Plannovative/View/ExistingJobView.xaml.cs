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
            
        }
    }
}
