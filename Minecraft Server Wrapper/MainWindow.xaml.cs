using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WinForms = System.Windows.Forms;
using System.IO;
using System.Windows.Media;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Configuration;

namespace Minecraft_Server_Wrapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServerWrapper serverWrapper = new ServerWrapper();

        public MainWindow()
        {
            InitializeComponent();
            ramLimit.Text = serverWrapper.ServerRAM.ToString();
            ServerFilePath.Text = serverWrapper.ServerPath;
            ForceOnlineMode.IsChecked = serverWrapper.ServerForceOnlineMode;
            RunServerOnStartUp.IsChecked = serverWrapper.RunServerOnStartUp;

            if (File.Exists(ServerFilePath.Text))
            {
                ShowInExplorer.IsEnabled = true;
                StartStopServer.IsEnabled = true;
                StatusLightColor(1);
            }
            if (ServerFilePath.Text == "...\\server.jar")
            {
                ShowInExplorer.IsEnabled = false;
                StartStopServer.IsEnabled = false;
                StatusIndicator.Content = "No server selected";
                StatusLightColor(0);
            }
            if (!File.Exists(ServerFilePath.Text) && ServerFilePath.Text != "...\\server.jar")
            {
                StatusIndicator.Content = "Could not find server file at last known path";
                StatusLightColor(0);
            }
            if (File.Exists(ServerFilePath.Text) && RunServerOnStartUp.IsChecked == true)
            {
                OnServerStart();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ApplicationShutdownHandler();
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

        DirectoryInfo WorkingDirectory;
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
                            ramLimit.Foreground = new SolidColorBrush(Colors.Black);
                            StatusIndicator.Content = "RAM Limit changed to " + ramLimit.Text + "MB";
                            serverWrapper.ServerRAM = Convert.ToInt32(ramLimit.Text);
                            serverWrapper.Save();
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
                        ramLimit.Foreground = new SolidColorBrush(Colors.Red);
                        StatusIndicator.Content = "RAM Limit must be an integer!";
                    }
                }

                //Check that given server file path actually exists
                if (File.Exists(ServerFilePath.Text))
                {
                    ServerPathExistsTestPass = true;
                    if (changedValue == "ServerPath")
                    {
                        WorkingDirectory = new DirectoryInfo(Path.GetDirectoryName(ServerFilePath.Text));
                        StatusIndicator.Content = "Server path changed";
                        ShowInExplorer.IsEnabled = true;
                        BackupWorld.IsEnabled = true;
                        EditServerProperties.IsEnabled = true;
                        serverWrapper.ServerPath = ServerFilePath.Text;
                        serverWrapper.Save();
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
                            BackupWorld.IsEnabled = false;
                            EditServerProperties.IsEnabled = false;
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

        //Auto Start Server Settings
        private void RunServerOnStartUp_Checked(object sender, RoutedEventArgs e)
        {
            serverWrapper.RunServerOnStartUp = true;
        }

        private void RunServerOnStartUp_Unchecked(object sender, RoutedEventArgs e)
        {
            serverWrapper.RunServerOnStartUp = false;
        }

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

        //Setting Server Path
        private void ServerFilePath_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ServerCheck("ServerPath");
        }

        //Managing Server Memory
        private void ramLimit_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ServerCheck("ramLimit");
        }

        private void ramLimit_MouseWheel(object sender, MouseWheelEventArgs e)
        {

            if (Convert.ToInt32(ramLimit.Text) + (e.Delta / 10 - 2) >= 0)
            {
                ramLimit.Text = (Convert.ToInt32(ramLimit.Text) + (e.Delta / 10 - 2)).ToString();
            }
            else
            {
                ramLimit.Text = "0";
            }
            ramLimit.ScrollToHome();
        }

        //Show Server in Explorer
        private void ShowInExplorer_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Path.GetDirectoryName(ServerFilePath.Text));
        }

        //Backup Server World
        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        
        bool WorldFoldersKnown;
        DirectoryInfo[] WorldFolders;
        int WorldFoldersIndex = 0;
        /*private async void CreateWorldBackup()
        {
            BackupWorld.IsEnabled = false;
            BackupWorld.Content = "Backing up Worlds";

            //Check backups directory exists
            if (!Directory.Exists(WorkingDirectory + @"\Backups"))
            {
                Directory.CreateDirectory(WorkingDirectory + @"\Backups");
            }

            //Find all world folders in server directory
            if (!WorldFoldersKnown)
            {
                DirectoryInfo[] Directories = WorkingDirectory.GetDirectories();

                int i = 0;
                foreach (var item in Directories)
                {
                    if (File.Exists(item + @"\level.dat"))
                    {
                        WorldFolders[i++] = item;
                    }
                }
                ServerOutputWindow.AppendText("\nNumber of worlds found: " + i);
                WorldFoldersKnown = true;
            }

            //Copy world folders to backup directory
            foreach (var item in WorldFolders)
            {
                ServerOutputWindow.AppendText("\nBacking up \"" + item.Name + "\" to ...\\Backups\\" + item.Name);
                DirectoryCopy(WorldFolders[WorldFoldersIndex].ToString(), WorkingDirectory + @"\Backups\ " + WorldFolders[WorldFoldersIndex].Name.ToString() + DateTime.Now, true);
            }

            BackupWorld.Content = "Backup Server World(s)";
            BackupWorld.IsEnabled = true;
        }*/
        
        private void BackupWorld_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => {
                BackupWorld.IsEnabled = false;
                BackupWorld.Content = "Backing up Worlds";

                //Check backups directory exists
                if (!Directory.Exists(WorkingDirectory + @"\Backups"))
                {
                    Directory.CreateDirectory(WorkingDirectory + @"\Backups");
                }

                //Find all world folders in server directory
                if (!WorldFoldersKnown)
                {
                    DirectoryInfo[] Directories = WorkingDirectory.GetDirectories();

                    int i = 0;
                    foreach (var item in Directories)
                    {
                        if (File.Exists(item + @"\level.dat"))
                        {
                            WorldFolders[i++] = new DirectoryInfo(item.ToString());
                            //WorldFolders[i++] = item;
                        }
                    }
                    ServerOutputWindow.AppendText("\nNumber of worlds found: " + i);
                    WorldFoldersKnown = true;
                }

                //Copy world folders to backup directory
                try
                {
                    foreach (var item in WorldFolders)
                    {
                        ServerOutputWindow.AppendText("\nBacking up \"" + item.Name + "\" to ...\\Backups\\" + item.Name);
                        DirectoryCopy(WorldFolders[WorldFoldersIndex].ToString(), WorkingDirectory + @"\Backups\ " + WorldFolders[WorldFoldersIndex].Name.ToString() + DateTime.Now, true);
                    }
                }
                catch (Exception f)
                {
                    ServerOutputWindow.AppendText(f.ToString());
                }

                BackupWorld.Content = "Backup Server World(s)";
                BackupWorld.IsEnabled = true;
            }));
        }

        //Editing Server Properties File
        private void EditServerProperties_Click(object sender, RoutedEventArgs e)
        {
            ServerPropertiesManager serverPropertiesManager = new ServerPropertiesManager();
            serverPropertiesManager.Show();
        }

        //Running Server
        ProcessStartInfo ServerArgs;
        Process ServerProcess = new Process();

        //Force Online mode toggle
        private void ForceOnlineMode_Checked(object sender, RoutedEventArgs e)
        {
            ServerArgs = new ProcessStartInfo("java", "-Xmx" + ramLimit.Text + "M -jar \"" + ServerFilePath.Text + "\" nogui -o");
            StatusIndicator.Content = "Force online mode enabled";
            
            ServerArgs.RedirectStandardInput = true;
            ServerArgs.RedirectStandardOutput = true;
            ServerArgs.UseShellExecute = false;
            ServerArgs.CreateNoWindow = true;

            serverWrapper.ServerForceOnlineMode = true;


        }

        private void ForceOnlineMode_Unchecked(object sender, RoutedEventArgs e)
        {
            ServerArgs = new ProcessStartInfo("java", "-Xmx" + ramLimit.Text + "M -jar \"" + ServerFilePath.Text + "\" nogui");
            StatusIndicator.Content = "Force online mode disabled";

            ServerArgs.RedirectStandardInput = true;
            ServerArgs.RedirectStandardOutput = true;
            ServerArgs.UseShellExecute = false;
            ServerArgs.CreateNoWindow = true;

            serverWrapper.ServerForceOnlineMode = false;
        }

        //RAM and CPU usage
        private void UpdateCpuRamUsageTimer()
        {
            Timer timer = new Timer();
            while (ServerIsRunning == true)
            {
                timer.Interval = 100;
                timer.Elapsed += new ElapsedEventHandler(UpdateCpuRamUsage_ElapsedEventHandler);
            }
        }

        private void UpdateCpuRamUsage_ElapsedEventHandler(object sender, EventArgs e)
        {
            ramUsageValue.Content = ServerProcess.WorkingSet64 / 1024 / 1024;
        }

        //If application is exited while server is running
        private void ApplicationShutdownHandler()
        {
            if (ServerIsRunning == true)
            {
                ServerProcess.OutputDataReceived -= new DataReceivedEventHandler(ServerOutput_OutputDataRecieved);
                ServerProcess.Exited -= new EventHandler(ServerClose_Exited);
                ServerProcess.Kill();
            }
        }

        //On server start and stop
        private void OnServerStart()
        {
            //Check that server arguements are valid
            if (ServerArgs == null)
            {
                ServerOutputWindow.AppendText("java -Xmx" + ramLimit.Text + "M -jar \"" + ServerFilePath.Text + "\" nogui\n");
                ServerArgs = new ProcessStartInfo("java", "-Xmx" + ramLimit.Text + "M -jar \"" + ServerFilePath.Text + "\" nogui");
                ServerArgs.RedirectStandardInput = true;
                ServerArgs.RedirectStandardOutput = true;
                ServerArgs.UseShellExecute = false;
                ServerArgs.CreateNoWindow = true;
            }

            //Start Server
            ServerProcess.StartInfo = ServerArgs;
            ServerProcess.EnableRaisingEvents = true;
            ServerProcess.OutputDataReceived += new DataReceivedEventHandler(ServerOutput_OutputDataRecieved);
            ServerProcess.Exited += new EventHandler(ServerClose_Exited);
            ServerProcess.Start();
            ServerProcess.BeginOutputReadLine();

            ServerIsRunning = true;
            
            BrowseServerFile.IsEnabled = false;
            KickAll.IsEnabled = true;
            opAll.IsEnabled = true;
            deopAll.IsEnabled = true;
            SendCommand.IsEnabled = true;

            StartStopServer.Content = "Stop Server";

            StatusIndicator.Content = "Server is Running | Server Process ID: " + ServerProcess.Id;
            StatusLightColor(2);
        }

        private void OnServerStop()
        {
            BrowseServerFile.IsEnabled = true;
            KickAll.IsEnabled = false;
            opAll.IsEnabled = false;
            deopAll.IsEnabled = false;
            SendCommand.IsEnabled = false;

            ServerIsRunning = false;
            StartStopServer.Content = "Start Server";
        }

        //Start and Stop Server Handler
        private void StartStopServer_Click(object sender, RoutedEventArgs e)
        {
            if (!ServerIsRunning)
            {
                OnServerStart();
            }
            else
            {
                //Stop Server
                ServerProcess.OutputDataReceived -= new DataReceivedEventHandler(ServerOutput_OutputDataRecieved);
                ServerProcess.Exited -= new EventHandler(ServerClose_Exited);
                ServerProcess.Kill();

                OnServerStop();

                ServerOutputWindow.AppendText("\nServer Closed");

                StatusIndicator.Content = "Server Closed";
                StatusLightColor(1);
            }
        }

        private void ServerOutput_OutputDataRecieved(object sender, DataReceivedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                ServerOutputWindow.AppendText(e.Data + "\n");
                ServerOutputWindow.ScrollToEnd();
            }));
        }

        private void ServerClose_Exited(object sender, EventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (ServerProcess.HasExited && !StartStopServer.IsPressed)
                {

                    ServerProcess.CancelOutputRead();
                    ServerProcess.OutputDataReceived -= new DataReceivedEventHandler(ServerOutput_OutputDataRecieved);
                    ServerProcess.Exited -= new EventHandler(ServerClose_Exited);
                    
                    ServerIsRunning = false;

                    StatusIndicator.Content = "Server Error";
                    StatusLightColor(0);

                    OnServerStop();
                }
            }));
        }

        //Commands
        string[] CommandHistory;
        int CommandHistoryIndex = 0; //Index of last stored command
        int CommandToGetIndex;

        private void UpdateCommandHistory()
        {
            if (CommandBox.Text != CommandHistory[CommandHistoryIndex])
            {
                CommandHistory[CommandHistoryIndex] = CommandBox.Text;
                CommandToGetIndex = CommandHistory.Length;
            }
        }

        private void SendCommand_Click(object sender, RoutedEventArgs e)
        {
            ServerProcess.StandardInput.WriteLine(CommandBox.Text);
            //UpdateCommandHistory();
        }

        private void CommandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                ServerProcess.StandardInput.Write(CommandBox.Text + Key.Tab);
            }

            if (e.Key == Key.Enter && ServerIsRunning)
            {
                ServerProcess.StandardInput.WriteLine(CommandBox.Text);
                //UpdateCommandHistory();
            }

            if (e.Key == Key.Up && CommandToGetIndex <= CommandHistory.Length)
            {/*
                CommandBox.Text = CommandHistory[CommandToGetIndex];
                CommandToGetIndex--;*/
            }

            if (e.Key == Key.Down && CommandToGetIndex >= CommandHistory.Length)
            {/*
                CommandBox.Text = CommandHistory[CommandToGetIndex];
                CommandToGetIndex++;*/
            }
        }
    }
}
