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

namespace InstanceManager.Windows
{
    /// <summary>
    /// Interaction logic for SelectProcessWindow.xaml
    /// </summary>
    public partial class SelectProcessWindow : Window
    {
        public SelectProcessWindow()
        {
            InitializeComponent();
            ProcessHelper.GetAllRunningProcesses();

            foreach (var process in ProcessHelper.AllRunningProcesses)
            {
                ProcessesListBox.Items.Add(process);
            }
        }

        private void SelectProcessBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedinstancename = ProcessesListBox.Items[ProcessesListBox.SelectedIndex].ToString();
            if (selectedinstancename == null)
            {
                //ignore, maybe log it later
            }
            else if (selectedinstancename != null)
            {
                ProcessHelper.FocusedProcessName = selectedinstancename;
                ProcessHelper.FocusedProcessPID = ProcessHelper.GetProcessPID(selectedinstancename);
                ProcessHelper.GetAllRunningInstancesOfFocusedProcess(selectedinstancename);
                ProcessHelper.IsSelectingProcess = false;

                this.Close();
            }
        }
    }
}
