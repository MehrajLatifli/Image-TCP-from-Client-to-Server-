using Image__TCP_Server_.View_Models;
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

namespace Image__TCP_Server_.Views
{
    /// <summary>
    /// Interaction logic for ServerMainWindow.xaml
    /// </summary>
    public partial class ServerMainWindow : Window
    {
        public ServerMainWindow()
        {
            InitializeComponent();


            var vm = new ServerMainViewModel() { ServerMainWindows = this };
            this.DataContext = vm;
        }
    }
}
