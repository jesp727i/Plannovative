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

namespace UserInterfaceLayer.View
{
    
    public partial class PlannovativeView : UserControl
    {
        public PlannovativeView()
        {
            InitializeComponent();
        }

        private void BtnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            CreateTaskView CTV = new CreateTaskView();
            CTV.ShowDialog();
        }
    }
}
