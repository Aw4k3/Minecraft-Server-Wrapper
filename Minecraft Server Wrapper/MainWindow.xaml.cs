using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WinForms = System.Windows.Forms;
using System.IO;
using System.Windows.Media;

namespace Minecraft_Server_Wrapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    DragMove();
            }
            catch (Exception)
            {

            }
        }

        //Main Code
        bool ServerIsRunning = false;

        private void BrowseServerFile_Click(object sender, RoutedEventArgs e)
        {
            WinForms.OpenFileDialog BrowseServerFileWindow = new WinForms.OpenFileDialog();
            BrowseServerFileWindow.Filter = ".jar|*.jar";

            if (BrowseServerFileWindow.ShowDialog() == WinForms.DialogResult.OK)
            {
                ServerFilePath.Text = BrowseServerFileWindow.FileName;
            }
        }

        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void ramLimit_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (IsTextAllowed(ramLimit.Text))
            {
                StartStopServer.IsEnabled = true;
                StatusIndicator.Content = "RAM Limit changed to " + ramLimit.Text + "MB";
                StatusLight.Fill = new SolidColorBrush(Colors.Orange);
            }
            else
            {
                StartStopServer.IsEnabled = false;
                StatusIndicator.Content = "RAM Limit must be an integer!";
                StatusLight.Fill = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
