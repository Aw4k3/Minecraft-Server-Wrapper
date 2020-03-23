﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WinForms = System.Windows.Forms;
using System.IO;
using System.Windows.Media;
using System.Timers;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Net;

namespace Minecraft_Server_Wrapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServerWrapper serverWrapper = new ServerWrapper();
        ServerPropertiesManager serverPropertiesManager = new ServerPropertiesManager();
        WrapperSettings wrapperSettings = new WrapperSettings();

        Color DefaultOutputColor;
        Color WarningOutputColor;
        Color ErrorOutputColor;
        Color PlayerEventOutputColor;
        Color ServerDoneLoadingColor;

        public MainWindow()
        {
            InitializeComponent();

            PublicIP.Content = new WebClient().DownloadString(new Uri("http://ipinfo.io/ip"));

            ramLimit.Text = serverWrapper.ServerRAM.ToString();
            ServerFilePath.Text = serverWrapper.ServerPath;
            //----------BUG: Force Online Mode prevents app from starting outside of debug folder----------
            /*
            if (serverWrapper.ServerForceOnlineMode)
            {
                ForceOnlineMode.IsChecked = serverWrapper.ServerForceOnlineMode;
                //VisualStateManager.GoToState(ForceOnlineMode, "CheckBoxChecked", true);
            }
            if (!serverWrapper.RunServerOnStartUp)
            {
                RunServerOnStartUp.IsChecked = serverWrapper.RunServerOnStartUp;
                //VisualStateManager.GoToState(RunServerOnStartUp, "CheckBoxChecked", true);
            }
            */

            TitleBar.Background = new SolidColorBrush(Color.FromRgb(serverWrapper.TitleBarColor.R, serverWrapper.TitleBarColor.G, serverWrapper.TitleBarColor.B));
            serverPropertiesManager.TitleBar.Background = new SolidColorBrush(Color.FromRgb(serverWrapper.TitleBarColor.R, serverWrapper.TitleBarColor.G, serverWrapper.TitleBarColor.B));
            wrapperSettings.TitleBar.Background = new SolidColorBrush(Color.FromRgb(serverWrapper.TitleBarColor.R, serverWrapper.TitleBarColor.G, serverWrapper.TitleBarColor.B));
            DefaultOutputColor = Color.FromRgb(serverWrapper.DefaultOutputColor.R, serverWrapper.DefaultOutputColor.G, serverWrapper.DefaultOutputColor.B);
            WarningOutputColor = Color.FromRgb(serverWrapper.WarningOutputColor.R, serverWrapper.WarningOutputColor.G, serverWrapper.WarningOutputColor.B);
            ErrorOutputColor = Color.FromRgb(serverWrapper.ErrorOutputColor.R, serverWrapper.ErrorOutputColor.G, serverWrapper.ErrorOutputColor.B);
            PlayerEventOutputColor = Color.FromRgb(serverWrapper.PlayerEventOutputColor.R, serverWrapper.PlayerEventOutputColor.G, serverWrapper.PlayerEventOutputColor.B);
            ServerDoneLoadingColor = Color.FromRgb(serverWrapper.ServerLoadingDoneColor.R, serverWrapper.ServerLoadingDoneColor.G, serverWrapper.ServerLoadingDoneColor.B);

            //Does server path exist and is auto start available
            if (File.Exists(ServerFilePath.Text))
            {
                ServerCheck("ServerPath");
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
            if (File.Exists(ServerFilePath.Text) && serverWrapper.RunServerOnStartUp == true)
            {
                OnServerStart();
            }

            //Skinning [wip]
            UpdateSkin(0.95f, serverWrapper.BackgroundSkin);
        }

        public void UpdateSkin(float Opacity, string BG_Path)
        {
            if (File.Exists(BG_Path))
            {

                switch (Path.GetExtension(serverWrapper.BackgroundSkin))
                {
                    case ".png":
                        GridWindow.Background = new ImageBrush(new BitmapImage(new Uri(serverWrapper.BackgroundSkin)));
                        break;

                    case ".jpg":
                        GridWindow.Background = new ImageBrush(new BitmapImage(new Uri(serverWrapper.BackgroundSkin)));
                        break;

                    case ".jpeg":
                        GridWindow.Background = new ImageBrush(new BitmapImage(new Uri(serverWrapper.BackgroundSkin)));
                        break;

                    case ".bmp":
                        GridWindow.Background = new ImageBrush(new BitmapImage(new Uri(serverWrapper.BackgroundSkin)));
                        break;

                    case ".mp4":

                        break;
                }
            }
        }

        private void PublicIP_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(PublicIP.Content.ToString());
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

        private void WrapperSettings_Click(object sender, RoutedEventArgs e)
        {
            new WrapperSettings().Show();
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

                        if (File.Exists(WorkingDirectory + @"\server.properties"))
                        {
                            EditServerProperties.IsEnabled = true;
                            serverPropertiesManager.ServerPropertiesValues = File.ReadAllLines(WorkingDirectory + @"\server.properties");
                            serverPropertiesManager.LoadSettings();
                        }
                        serverWrapper.ServerPath = ServerFilePath.Text;
                        serverWrapper.Save();

                        ModPluginWindow.Items.Clear();

                        if (Directory.Exists(WorkingDirectory + @"\plugins"))
                        {
                            ModPluginsTabItem.Header = "Plugins";
                            string[] _Plugins = Directory.GetFiles(WorkingDirectory + @"\plugins");
                            foreach (var item in _Plugins)
                            {
                                ModPluginWindow.Items.Add(Path.GetFileNameWithoutExtension(item));
                            }
                        }

                        if (Directory.Exists(WorkingDirectory + @"\mods"))
                        {
                            ModPluginsTabItem.Header = "Mods";
                            string[] _Mods = Directory.GetFiles(WorkingDirectory + @"\mods");
                            foreach (var item in _Mods)
                            {
                                ModPluginWindow.Items.Add(Path.GetFileNameWithoutExtension(item));
                            }
                        }
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
                    StartStopServerSettings.IsEnabled = true;
                    StartStopServer.IsEnabled = true;
                    StatusLightColor(1);
                }
                else
                {
                    StartStopServerSettings.IsEnabled = false;
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

        private void ServerFilePath_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Mouse.MiddleButton == MouseButtonState.Pressed)
            {
                ServerFilePath.Clear();
                ServerCheck("ServerPath");
            }
        }

        //Run Server Settings
        private void StartStopServerSettings_Click(object sender, RoutedEventArgs e)
        {
            new ServerStartSettings().Show();
        }

        //Managing Server Mods/Plugins
        private void PluginsModItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(WorkingDirectory + @"\mods"))
            {
                File.Delete(WorkingDirectory + @"\mods\" + ModPluginWindow.SelectedItem.ToString());
            }
            if (Directory.Exists(WorkingDirectory + @"\plugins"))
            {
                File.Delete(WorkingDirectory + @"\plugins\" + ModPluginWindow.SelectedItem.ToString());
            }
        }

        private void PluginsModItemOpenFileLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(WorkingDirectory + @"\mods"))
            {
                Process.Start("explorer.exe", WorkingDirectory + @"\mods\" + ModPluginWindow.SelectedItem.ToString());
            }
            if (Directory.Exists(WorkingDirectory + @"\plugins"))
            {
                Process.Start("explorer.exe", WorkingDirectory + @"\plugins\" + ModPluginWindow.SelectedItem.ToString());
            }
        }

        //Managing Server Memory
        private void ramLimit_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ServerCheck("ramLimit");
        }

        private void ramLimit_MouseWheel(object sender, MouseWheelEventArgs e)
        {

            if (e.Delta > 0)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control)
                {
                    ramLimit.Text = (Convert.ToInt32(ramLimit.Text) + 1).ToString();
                }
                else if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    ramLimit.Text = (Convert.ToInt32(ramLimit.Text) + 128).ToString();
                }
                else
                {
                    ramLimit.Text = (Convert.ToInt32(ramLimit.Text) + 1024).ToString();
                }
            }
            if (e.Delta < 0)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control)
                {
                    ramLimit.Text = (Convert.ToInt32(ramLimit.Text) - 1).ToString();
                }
                else if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    ramLimit.Text = (Convert.ToInt32(ramLimit.Text) - 128).ToString();
                }
                else
                {
                    ramLimit.Text = (Convert.ToInt32(ramLimit.Text) - 1024).ToString();
                }

                if (Convert.ToInt32(ramLimit.Text) < 0)
                {
                    ramLimit.Text = "0";
                }
            }
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
        
        private async void BackupWorld_Click(object sender, RoutedEventArgs e)
        {
            new Task(async () =>
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
            });
        }

        //Clear Server Output
        private void ClearOutputWindow_Click(object sender, RoutedEventArgs e)
        {
            ServerOutputWindow.Document.Blocks.Clear();
        }

        //Editing Server Properties File
        private void EditServerProperties_Click(object sender, RoutedEventArgs e)
        {
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

        Stopwatch ServerUptime = new Stopwatch();
        //RAM and CPU usage and Server Uptime
        private void UpdateCpuRamUsageTimer(bool StartTimer)
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(UpdateCpuRamUsage_ElapsedEventHandler);

            Timer UpTimeTick = new Timer();
            UpTimeTick.Interval = 1000;
            UpTimeTick.AutoReset = true;
            UpTimeTick.Elapsed += new ElapsedEventHandler(UpdateServerUptime);
            if (StartTimer)
            {
                timer.Start();
                UpTimeTick.Start();
                ServerUptime.Start();
            }
            if (!StartTimer)
            {
                timer.Stop();
                UpTimeTick.Stop();
                ServerUptime.Stop();
                ServerUptime.Reset();
            }
        }

        private void UpdateServerUptime(object sender, ElapsedEventArgs e)
        {
            if (ServerIsRunning)
            {
                Dispatcher.Invoke(() => {
                    StatusIndicator.Content = "Server is Running | Server Process ID: " + ServerProcess.Id + " | Server Uptime: " + ServerUptime.Elapsed.ToString("hh\\:mm\\:ss");
                });
            }
        }

        private void UpdateCpuRamUsage_ElapsedEventHandler(object sender, EventArgs e)
        {
            if (ServerIsRunning)
            {
                Dispatcher.Invoke(() =>
                {
                    ramUsageValue.Content = "RAM Usage: " + ServerProcess.WorkingSet64 / (1024 * 1024) + "MB";
                });
            }
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
                ServerProcess.StartInfo.WorkingDirectory = WorkingDirectory.ToString();
                ServerOutputWindow.AppendText("java -Xmx" + ramLimit.Text + "M -jar \"" + ServerFilePath.Text + "\" nogui\n");
                ServerArgs = new ProcessStartInfo("java", "-Xmx" + ramLimit.Text + "M -jar \"" + ServerFilePath.Text + "\" nogui");
                ServerArgs.RedirectStandardInput = true;
                ServerArgs.RedirectStandardOutput = true;
                ServerArgs.UseShellExecute = false;
                ServerArgs.CreateNoWindow = true;
            }

            //Start Server
            ServerProcess.StartInfo = ServerArgs;
            ServerProcess.StartInfo.WorkingDirectory = WorkingDirectory.ToString();
            ServerProcess.EnableRaisingEvents = true;
            ServerProcess.OutputDataReceived += new DataReceivedEventHandler(ServerOutput_OutputDataRecieved);
            ServerProcess.Exited += new EventHandler(ServerClose_Exited);
            ServerProcess.Start();
            ServerProcess.BeginOutputReadLine();

            ServerIsRunning = true;
            
            BrowseServerFile.IsEnabled = false;
            ServerFilePath.IsEnabled = false;
            ForceOnlineMode.IsChecked = false;
            ramLimit.IsEnabled = false;
            KickAll.IsEnabled = true;
            BanAll.IsEnabled = true;
            opAll.IsEnabled = true;
            deopAll.IsEnabled = true;
            SendCommand.IsEnabled = true;

            StartStopServer.Content = "Stop Server";

            StatusIndicator.Content = "Server is Running | Server Process ID: " + ServerProcess.Id;
            StatusLightColor(2);

            UpdateCpuRamUsageTimer(true);
        }

        private void OnServerStop()
        {
            UpdateCpuRamUsageTimer(false);
            ServerIsRunning = false;
            ServerProcess.CancelOutputRead();
            BrowseServerFile.IsEnabled = true;
            ServerFilePath.IsEnabled = true;
            ForceOnlineMode.IsEnabled = true;
            ramLimit.IsEnabled = true;
            KickAll.IsEnabled = false;
            BanAll.IsEnabled = false;
            opAll.IsEnabled = false;
            deopAll.IsEnabled = false;
            SendCommand.IsEnabled = false;

            ServerOutputWindow.AppendText("\nServer Closed");
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
                UpdateCpuRamUsageTimer(false);
                ServerProcess.OutputDataReceived -= new DataReceivedEventHandler(ServerOutput_OutputDataRecieved);
                ServerProcess.Exited -= new EventHandler(ServerClose_Exited);
                ServerProcess.Kill();

                OnServerStop();
                StatusIndicator.Content = "Server Closed";
                StatusLightColor(1);
            }
        }

        private void ServerOutput_OutputDataRecieved(object sender, DataReceivedEventArgs e)
        {
            Dispatcher.InvokeAsync(new Action(() =>
            {
                try
                {
                    if (e.Data.Contains("WARN"))
                    {
                        ServerOutputWindow.AppendText(e.Data + "\n");
                        TextRange WarnOutputTextRange = new TextRange(ServerOutputWindow.Document.ContentEnd, ServerOutputWindow.Document.ContentEnd);
                        WarnOutputTextRange.Text = e.Data;
                        WarnOutputTextRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(WarningOutputColor));
                    }
                    else if (e.Data.Contains("ERROR"))
                    {
                        ServerOutputWindow.AppendText(e.Data + "\n");
                        TextRange ErrorOutputTextRange = new TextRange(ServerOutputWindow.Document.ContentEnd, ServerOutputWindow.Document.ContentEnd);
                        ErrorOutputTextRange.Text = e.Data;
                        ErrorOutputTextRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(ErrorOutputColor));
                    }
                    else if (e.Data.Contains("logged in with") || e.Data.Contains("left the game"))
                    {
                        ServerOutputWindow.AppendText(e.Data + "\n");
                        TextRange PlayEventTextRange = new TextRange(ServerOutputWindow.Document.ContentEnd, ServerOutputWindow.Document.ContentEnd);
                        PlayEventTextRange.Text = e.Data;
                        PlayEventTextRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(PlayerEventOutputColor));
                    }
                    else if (e.Data.Contains("Done") && e.Data.Contains("For help, type \"help\""))
                    {
                        ServerOutputWindow.AppendText(e.Data + "\n");
                        TextRange PlayEventTextRange = new TextRange(ServerOutputWindow.Document.ContentEnd, ServerOutputWindow.Document.ContentEnd);
                        PlayEventTextRange.Text = e.Data;
                        PlayEventTextRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(ServerDoneLoadingColor));
                    }
                    else
                    {
                        ServerOutputWindow.AppendText(e.Data + "\n");
                        TextRange DefaultOutputTextRange = new TextRange(ServerOutputWindow.Document.ContentEnd, ServerOutputWindow.Document.ContentEnd);
                        DefaultOutputTextRange.Text = e.Data;
                        DefaultOutputTextRange.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(DefaultOutputColor));
                    }
                }
                catch (Exception)
                {

                }
                
                ServerOutputWindow.ScrollToEnd();
            }));
        }

        private void ServerClose_Exited(object sender, EventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (ServerProcess.HasExited && !StartStopServer.IsPressed)
                {
                    ServerIsRunning = false;
                    UpdateCpuRamUsageTimer(false);
                    ServerProcess.CancelOutputRead();
                    ServerProcess.OutputDataReceived -= new DataReceivedEventHandler(ServerOutput_OutputDataRecieved);
                    ServerProcess.Exited -= new EventHandler(ServerClose_Exited);
                    
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
            string[] CommandsToSend;
            CommandsToSend = CommandBox.Text.Split(Convert.ToChar(";"));
            foreach (var item in CommandsToSend)
            {
                ServerProcess.StandardInput.WriteLine(item.Trim());
            }
            CommandBox.Clear();
            //UpdateCommandHistory();
        }

        private void CommandBox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                CommandBox.Clear();
            }
        }

        private void CommandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                //ServerProcess.StandardInput.Write(CommandBox.Text + Key.Tab);
            }

            if (e.Key == Key.Enter && ServerIsRunning)
            {
                string[] CommandsToSend;
                CommandsToSend = CommandBox.Text.Split(';');
                foreach (var item in CommandsToSend)
                {
                    ServerProcess.StandardInput.WriteLine(item.Trim());
                }
                CommandBox.Clear();
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

        private void QuickCommand(object sender, RoutedEventArgs e)
        {
            if (sender == KickAll)
            {
                ServerProcess.StandardInput.WriteLine("kick @a");
            }
            if (sender == BanAll)
            {
                ServerProcess.StandardInput.WriteLine("ban @a");
            }
            if (sender == opAll)
            {
                ServerProcess.StandardInput.WriteLine("op @a");
            }
            if (sender == deopAll)
            {
                ServerProcess.StandardInput.WriteLine("deop @a");
            }
        }

        private void ServeroutputWindowScale_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ServeroutputWindowScale.Text != "" && ServeroutputWindowScale.Text != "%")
            {
                double scale = Convert.ToDouble(Regex.Replace(ServeroutputWindowScale.Text, "[^0-9]", "")); //Remove any non numeric characters from scale to use in code
                if (scale >= 1)
                {
                    ServerOutputWindow.FontSize = (scale / 100) * 12;
                }
            }
        }

        private void ServeroutputWindowScale_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ServeroutputWindowScale.Text[ServeroutputWindowScale.Text.Length - 1] != '%')
            {
                ServeroutputWindowScale.Text += "%";
            }
        }

        private void ServerOutputWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            /*while (Keyboard.Modifiers == ModifierKeys.Control)
            {
                double scale = Convert.ToDouble(Regex.Replace(ServeroutputWindowScale.Text, "[^0-9]", ""));
                if (e.Delta > 0)
                {
                    scale += 5;
                    ServeroutputWindowScale.Text = scale + "%";
                    ServerOutputWindow.FontSize = (scale / 100) * 12;
                }
                if (e.Delta < 0)
                {
                    scale -= 5;
                    if (scale < 1)
                    {
                        scale = 1;
                    }
                    else
                    {
                        
                    }
                    ServerOutputWindow.FontSize = (scale / 100) * 12;
                    ServeroutputWindowScale.Text = scale + "%";
                }
            }*/
        }
    }
}
