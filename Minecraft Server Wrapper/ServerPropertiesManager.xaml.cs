using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media.Animation;
using System.Collections.Generic;

namespace Minecraft_Server_Wrapper
{
    /// <summary>
    /// Interaction logic for ServerPropertiesManager.xaml
    /// </summary>
    public partial class ServerPropertiesManager : Window
    {
        public string[] ServerPropertiesValues;


        public ServerPropertiesManager()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
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

        private void SettingSearch_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingSearch.Clear();
        }
        
        Grid grid = new Grid();
        //List<Canvas> CanvasArray = new List<Canvas>();
        

        private void SettingSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UIElementCollection uIElementCollection = new UIElementCollection(this, grid);
            string searchQuery = Regex.Replace(SettingSearch.Text.ToLower(), @"\s+", ""); //Remove Spaces
            if (SettingSearch.Text == "")
            {
                foreach (Canvas canvas in uIElementCollection)
                {
                    canvas.Opacity = 1;
                }
            }

            if (searchQuery != "")
            {
                try { SettingDescription.Content = searchQuery; } catch (Exception) { }

                foreach (Canvas canvas in uIElementCollection)
                {
                    if (!canvas.Name.ToLower().Contains(searchQuery))
                    {
                        SettingDescription.Content += canvas.Name;
                        canvas.Opacity = 0.5;
                    }
                }
            }
        }

        public void LoadSettings()
        {
            //Remove Comment Lines obtained while collecting values from server.properties
            for (int i = 0; i < ServerPropertiesValues.Length - 2; i++)
            {
                ServerPropertiesValues[i] = ServerPropertiesValues[i + 2];
            }

            //Showing Values
            UIElementCollection uIElementCollection = new UIElementCollection(this, grid);

            foreach (Label label in uIElementCollection)
            {
                uIElementCollection.Remove(label);
            }

            SpawnProtectionValue.Text = GetStrVal("spawn-protection");
            MaxTickTimeValue.Text = GetStrVal("max-tick-time");
            QueryPortValue.Text = GetStrVal("query.port");
            GeneratingSettingsValue.Text = GetStrVal("generator-settings");
            ForceGamemodeValue.IsChecked = GetBoolVal("force-gamemode", ForceGamemodeValue);
            /*
            if (GetBoolVal("force-gamemode", ForceGamemodeValue))
            {
                ForceGamemodeValue.BeginStoryboard((Storyboard)ForceGamemodeValue.FindResource("CheckBoxChecking"));
                ForceGamemodeValue.IsChecked = true;
            }
            */

        }

        //Obtaining data from Server.properties
        private string GetStrVal(string ValToFind)
        {
            string result = "";

            foreach (var item in ServerPropertiesValues)
            {
                if (item.Contains(ValToFind))
                {
                    result = item.Split('=').Last();
                }
            }

            return result;
        }

        private bool GetBoolVal(string ValToFind, CheckBox checkBox)
        {
            bool result = false;

            foreach (var item in ServerPropertiesValues)
            {
                if (item.Contains(ValToFind))
                {
                    Boolean.TryParse(item.Split('=').Last(), out result);
                }
            }

            if (result)
            {
                checkBox.IsChecked = true;
                checkBox.BeginStoryboard(grid.FindResource("CheckBoxChecking") as Storyboard);
            }

            return result;
        }
    }
}
