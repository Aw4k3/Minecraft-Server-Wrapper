using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media.Animation;

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
        private void SettingSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchQuery = Regex.Replace(SettingSearch.Text.ToLower(), @"\s+", "");
            if (SettingSearch.Text == null)
            {
                foreach (Label label in grid.Children)
                {
                    label.Opacity = 1;
                }
                foreach (CheckBox checkbox in grid.Children)
                {
                    checkbox.Opacity = 1;
                }
                foreach (TextBox textBox in grid.Children)
                {
                    if (textBox.Name != "SettingSearch")
                    {
                        textBox.Opacity = 1;
                    }
                }
                foreach (ComboBox combobox in grid.Children)
                {
                    combobox.Opacity = 1;
                }
            }

            if (searchQuery != null)
            {
                try
                {
                    SettingDescription.Content = searchQuery;
                }
                catch (Exception)
                {
                }

                foreach (Label label in grid.Children)
                {
                    SettingDescription.Content = label.Content;
                    string i = Regex.Replace(label.Content.ToString().ToLower(), @"\s+", "");
                    if (!i.Contains(searchQuery))
                    {
                        label.Opacity = 0.5;
                        SettingDescription.Content = label.Opacity.ToString();
                    }
                }
                foreach (CheckBox checkbox in grid.Children)
                {
                    string i = Regex.Replace(checkbox.Content.ToString().ToLower(), @"\s+", "");
                    if (!i.Contains(searchQuery))
                    {
                        checkbox.Opacity = 0.5;
                    }
                }
                foreach (TextBox textbox in grid.Children)
                {
                    string i = Regex.Replace(textbox.Text.ToLower(), @"\s+", "");
                    if (!i.Contains(searchQuery) && textbox.Name != "SettingsSearch")
                    {
                        textbox.Opacity = 0.5;
                    }
                }
                foreach (ComboBox combobox in grid.Children)
                {
                    string i = Regex.Replace(combobox.Name.ToLower(), @"\s+", "");
                    if (!i.Contains(searchQuery))
                    {
                        combobox.Opacity = 0.5;
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
            //ForceGamemodeValue.IsChecked = GetBoolVal("force-gamemode", ForceGamemodeValue);
            if (GetBoolVal("force-gamemode", ForceGamemodeValue))
            {
                ForceGamemodeValue.BeginStoryboard((Storyboard)ForceGamemodeValue.FindResource("CheckBoxChecking"));
                ForceGamemodeValue.IsChecked = true;
            }

        }

        private string GetStrVal(string ValToFind)
        {
            string result = "";

            foreach (var item in ServerPropertiesValues)
            {
                if (item.Contains(ValToFind))
                {
                    result = item.Split(Convert.ToChar("=")).Last();
                }
            }

            return result;
        }

        private bool GetBoolVal(string ValToFind, CheckBox CheckBox)
        {
            bool result = false;

            foreach (var item in ServerPropertiesValues)
            {
                if (item.Contains(ValToFind))
                {
                    result = Convert.ToBoolean(item.Split(Convert.ToChar("=")).Last());
                }
            }
            /*
            if (result)
            {
                CheckBox.BeginStoryboard(grid.FindResource("CheckBoxChecking") as Storyboard);
            }
            */
            return result;
        }
    }
}
