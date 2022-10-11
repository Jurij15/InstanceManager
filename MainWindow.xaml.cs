using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;
using InstanceManager.Windows;

namespace InstanceManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer livetime = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();

        void timer_tick(object sender, EventArgs e)
        {

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectAProcessBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ProcessHelper.IsSelectingProcess)
            {
                SelectProcessWindow selprocwin = new SelectProcessWindow();
                selprocwin.ShowDialog();
                ProcessHelper.IsSelectingProcess = true;
            }

            foreach (var FocusedProcessInstance in ProcessHelper.FocusedProcessesList)
            {
                InstancesListBox.Items.Add(FocusedProcessInstance);
            }
        }
    }
}
