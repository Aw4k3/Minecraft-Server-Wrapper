using System;
using System.IO;
using System.Net;
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
        string UserTempPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\Minecraft Server Wrapper";
        string[,] ForgeServerURLs;
        public CreateNewServer()
        {
            InitializeComponent();
            if (!Directory.Exists(UserTempPath))
            {
                Directory.CreateDirectory(UserTempPath);
            }
            new WebClient().DownloadFile(new Uri("https://github.com/Aw4k3/Minecraft-Server-Wrapper/blob/master/Minecraft%20Server%20Wrapper/Server%20Links/Forge.txt"), UserTempPath + @"\ForgeDownloadURLs.txt");
            MessageBox.Show(File.ReadAllText(UserTempPath + @"\ForgeDownloadURLs.txt"));
            //Get Forge server links
            string[] ServerUrls = File.ReadAllLines(UserTempPath + @"\ForgeDownloadURLs.txt");
            for (int i = 0; i < ServerUrls.Length; i++)
            {
                string[] temp = ServerUrls[i].Split(',');
                ForgeServerURLs[0, i] = temp[0];
                ForgeServerURLs[1, i] = temp[1];
            }
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

        private void URLFetcher(string ServerType, string ServerVersion)
        {
            switch (ServerType)
            {
                case "Vanilla":
                    SelectServerVersion.Items.Clear();
                    break;
                case "Forge":
                    SelectServerVersion.Items.Clear();
                    for (int i = 0; i < ForgeServerURLs.GetLength(1); i++)
                    {
                        SelectServerVersion.Items.Add(ForgeServerURLs[0, i]);
                    }
                    break;
                case "Bukkit":
                    SelectServerVersion.Items.Clear();
                    break;
                case "CraftBukkit":
                    SelectServerVersion.Items.Clear();
                    break;
                case "Spigot":
                    SelectServerVersion.Items.Clear();
                    break;
            }
        }

        private void URLLoader(string Data, string[,] URLArray)
        {
            MessageBox.Show(Data);
            int x = 0, y = 0;
            foreach (var row in Data.Split('\n'))
            {
                x = 0;
                foreach (var item in row.Split(','))
                {
                    URLArray[x++, y] = item;
                }
                y++;
            }
        }

        private void SelectServerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SelectServerType.Text)
            {
                case "Vanilla":
                    break;
                case "Forge":
                    SelectServerVersion.Items.Clear();
                    for (int i = 0; i < ForgeServerURLs.GetLength(1); i++)
                    {
                        SelectServerVersion.Items.Add(ForgeServerURLs[0, i]);
                    }

                    if (SelectServerType.Text == "Forge")
                    {
                        ServerTypeInfo.Opacity = 1;
                        ServerTypeInfo.ToolTip = "Forge installer will be downloaded and launched";
                    }
                    else
                    {
                        ServerTypeInfo.Opacity = 0;
                        ServerTypeInfo.ToolTip = "";
                    }
                    break;
            }
            URLFetcher(SelectServerType.Text, SelectServerVersion?.Text);
            
        }

        private void SelectServerVersion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            URLFetcher(SelectServerType.Text, SelectServerVersion.Text);
        }
    }
}
