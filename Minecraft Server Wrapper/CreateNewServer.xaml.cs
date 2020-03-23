using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WinForms = System.Windows.Forms;

namespace Minecraft_Server_Wrapper
{
    /// <summary>
    /// Interaction logic for CreateNewServer.xaml
    /// </summary>
    public partial class CreateNewServer : Window
    {
        public CreateNewServer()
        {
            InitializeComponent();
        }

        //Managing Window
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

        //Managing Server Install Path
        private void ServerDir_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Directory.Exists(ServerDir.Text))
            {
                DownloadInstall.IsEnabled = true;
            }
        }

        private void BrowseServerFile_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog SelectServerDir = new WinForms.FolderBrowserDialog();
            if (SelectServerDir.ShowDialog() == WinForms.DialogResult.OK)
            {
                ServerDir.Text = SelectServerDir.SelectedPath;
                DownloadInstall.IsEnabled = true;
            }
        }

        //Managing which server to download
        Uri ServerDownloadURL;

        private void URLConstructor(string ServerType, string ServerVersion)
        {
            switch (ServerType)
            {
                case "Vanilla":
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
