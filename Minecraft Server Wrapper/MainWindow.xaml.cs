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
            if (File.Exists(ServerFilePath.Text))
            {
                ShowInExplorer.IsEnabled = true;
                StartStopServer.IsEnabled = true;
                StatusLightColor(1);
            }
            else
            {
                try
                {
                    ShowInExplorer.IsEnabled = false;
                    StartStopServer.IsEnabled = false;
                    StatusIndicator.Content = "No server selected";
                    StatusLightColor(0);
                }
                catch (Exception)
                {

                }
            }
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

        private void StatusLightColor(int x)
        {
            if (x == 0) { StatusLight.Fill = new SolidColorBrush(Colors.Red); }
            if (x == 1) { StatusLight.Fill = new SolidColorBrush(Colors.Orange); }
            if (x == 2) { StatusLight.Fill = new SolidColorBrush(Colors.Lime); }
        }

        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void ServerCheck(string changedValue)
        {
            bool ramLimitTestPass = false;
            bool ServerPathExistsTestPass = false;
            try
            {
                //Check if entered RAM is an Integer
                if (IsTextAllowed(ramLimit.Text))
                {
                    try
                    {
                        ramLimitTestPass = true;
                        if (changedValue == "ramLimit")
                        {
                            StatusIndicator.Content = "RAM Limit changed to " + ramLimit.Text + "MB";
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    ramLimitTestPass = false;
                    if (changedValue == "ramLimit")
                    {
                        StatusIndicator.Content = "RAM Limit must be an integer!";
                    }
                }

                //Check that given server file path actually exists
                if (File.Exists(ServerFilePath.Text))
                {
                    ServerPathExistsTestPass = true;
                    if (changedValue == "ServerPath")
                    {
                        StatusIndicator.Content = "Server path changed";
                        ShowInExplorer.IsEnabled = true;
                    }
                }
                else
                {
                    try
                    {
                        ServerPathExistsTestPass = false;
                        if (changedValue == "ServerPath")
                        {
                            StatusIndicator.Content = "Server path is invalid!";
                            ShowInExplorer.IsEnabled = false;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                if (ramLimitTestPass && ServerPathExistsTestPass)
                {
                    StartStopServer.IsEnabled = true;
                    StatusLightColor(1);
                }
                else
                {
                    StartStopServer.IsEnabled = false;
                    StatusLightColor(0);
                }
            }
            catch (Exception)
            {

            }
        }

        //Main Code
        bool ServerIsRunning = false;
        //Managing Server Path
        private void BrowseServerFile_Click(object sender, RoutedEventArgs e)
        {
            WinForms.OpenFileDialog BrowseServerFileWindow = new WinForms.OpenFileDialog();
            BrowseServerFileWindow.Filter = ".jar|*.jar";

            if (BrowseServerFileWindow.ShowDialog() == WinForms.DialogResult.OK)
            {
                ServerFilePath.Text = BrowseServerFileWindow.FileName;
                StatusIndicator.Content = "Server path changed";
                StatusLightColor(1);
            }
        }

        private void ServerFilePath_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ServerCheck("ServerPath");
        }

        //Managing Server Memory
        private void ramLimit_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ServerCheck("ramLimit");
        }

        //Show server in Explorer
        private void ShowInExplorer_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Path.GetDirectoryName(ServerFilePath.Text));
        }

        //Running Server
        ProcessStartInfo ServerArgs;
        Process ServerProcess = new Process();

        //Force Online mode toggle
        private void ForceOnlineMode_Checked(object sender, RoutedEventArgs e)
        {
            if (ForceOnlineMode.IsChecked == true)
            {
                ServerArgs = new ProcessStartInfo("java", "-Xmx" + ramLimit.Text + "M -jar " + ServerFilePath.Text + " nogui -o");
            }
            else
            {
                ServerArgs = new ProcessStartInfo("java", "-Xmx" + ramLimit.Text + "M -jar " + ServerFilePath.Text + " nogui");
            }
            ServerArgs.RedirectStandardInput = ServerArgs.RedirectStandardError = true;
            ServerArgs.UseShellExecute = false;
            ServerArgs.CreateNoWindow = true;
        }

        //Start and Stop Server Handline
        private void StartStopServer_Click(object sender, RoutedEventArgs e)
        {
            //Check that server arguements are valid
            if (ServerArgs == null)
            {
                ServerOutputWindow.AppendText("Error loading Server Arguements");
                ServerOutputWindow.AppendText("Using default Server Arguements");
                ServerOutputWindow.AppendText("java -Xmx" + ramLimit.Text + "M -jar " + ServerFilePath.Text + " nogui");
                ServerArgs = new ProcessStartInfo("java", "-Xmx" + ramLimit.Text + "M -jar " + ServerFilePath.Text + " nogui");
                ServerArgs.RedirectStandardInput = ServerArgs.RedirectStandardError = true;
                ServerArgs.UseShellExecute = false;
                ServerArgs.CreateNoWindow = true;
            }

            
            if (ServerIsRunning == false)
            {
                //Start Server
                ServerProcess.StartInfo = ServerArgs;
                ServerProcess.EnableRaisingEvents = true;
                ServerProcess.ErrorDataReceived += new DataReceivedEventHandler(ServerOutput_ErrorDataRecieved);
                ServerProcess.Exited += new EventHandler(ServerClose_Exited);
                ServerProcess.Start();
                ServerProcess.BeginErrorReadLine();

                ServerIsRunning = true;

                BrowseServerFile.IsEnabled = false;
                KickAll.IsEnabled = true;
                opAll.IsEnabled = true;
                deopAll.IsEnabled = true;
                SendCommand.IsEnabled = true;

                StartStopServer.Content = "Stop Server";

                StatusIndicator.Content = "Server is Running";
                StatusLightColor(2);
            }
            else
            {
                //Stop Server
                BrowseServerFile.IsEnabled = true;
                KickAll.IsEnabled = false;
                opAll.IsEnabled = false;
                deopAll.IsEnabled = false;
                SendCommand.IsEnabled = false;

                ServerProcess.Close();

                ServerIsRunning = false;
                StartStopServer.Content = "Start Server";
                StatusIndicator.Content = "Server closed";
                StatusLightColor(1);
            }
        }

        private void ServerOutput_ErrorDataRecieved(object sender, DataReceivedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                ServerOutputWindow.AppendText(e.Data);
            }));
        }

        private void ServerClose_Exited(object sender, EventArgs e)
        {

            Dispatcher.Invoke(new Action(() =>
            {
                if (ServerProcess.HasExited && !StartStopServer.IsPressed)
                {
                    StatusIndicator.Content = "Server Error";
                    StatusLightColor(0);

                    BrowseServerFile.IsEnabled = true;
                    KickAll.IsEnabled = false;
                    opAll.IsEnabled = false;
                    deopAll.IsEnabled = false;
                    SendCommand.IsEnabled = false;

                    StartStopServer.Content = "Start Server";
                }
            }));
        }
    }
}
