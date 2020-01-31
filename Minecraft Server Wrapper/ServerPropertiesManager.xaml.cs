using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        public void LoadSettings()
        {
            for (int i = 0; i < ServerPropertiesValues.Length - 2; i++)
            {
                ServerPropertiesValues[i] = ServerPropertiesValues[i + 2];
            }
        }

        private void SettingSearch_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            SettingSearch.Clear();
        }

        private void SettingSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Grid grid = new Grid();
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
                foreach (Label label in grid.Children)
                {
                    string i = Regex.Replace(label.Content.ToString().ToLower(), @"\s+", "");
                    if (!i.Contains(searchQuery))
                    {
                        label.Opacity = 0.5;
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
    }
}
