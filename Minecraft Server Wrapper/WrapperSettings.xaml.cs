using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Minecraft_Server_Wrapper
{
    /// <summary>
    /// Interaction logic for WrapperSettings.xaml
    /// </summary>
    public partial class WrapperSettings : Window
    {
        ServerWrapper ServerWrapper = new ServerWrapper();
        ColorPicker ColorPicker = new ColorPicker();

        public WrapperSettings()
        {
            InitializeComponent();
            TitleBarColor.Fill = new SolidColorBrush(Color.FromRgb(ServerWrapper.TitleBarColor.R, ServerWrapper.TitleBarColor.G, ServerWrapper.TitleBarColor.B));
            WarningOutputColor.Fill = new SolidColorBrush(Color.FromRgb(ServerWrapper.WarningOutputColor.R, ServerWrapper.WarningOutputColor.G, ServerWrapper.WarningOutputColor.B));
            ErrorOutputColor.Fill = new SolidColorBrush(Color.FromRgb(ServerWrapper.ErrorOutputColor.R, ServerWrapper.ErrorOutputColor.G, ServerWrapper.ErrorOutputColor.B));
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

        private void TitleBarColor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ColorPicker.DialogResult == true)
            {
                TitleBarColor.Fill = new SolidColorBrush(ColorPicker.FinalRGBResult);
                ServerWrapper.TitleBarColor = System.Drawing.Color.FromArgb(1, ColorPicker.FinalRGBResult.R, ColorPicker.FinalRGBResult.G, ColorPicker.FinalRGBResult.B);
                ServerWrapper.Save();
            }
        }

        private void DefaultOutputColor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ColorPicker.DialogResult == true)
            {
                DefaultOutputColor.Fill = new SolidColorBrush(ColorPicker.FinalRGBResult);
                ServerWrapper.DefaultOutputColor = System.Drawing.Color.FromArgb(1, ColorPicker.FinalRGBResult.R, ColorPicker.FinalRGBResult.G, ColorPicker.FinalRGBResult.B);
                ServerWrapper.Save();
            }
        }

        private void WarningOutputColor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ColorPicker.DialogResult == true)
            {
                WarningOutputColor.Fill = new SolidColorBrush(ColorPicker.FinalRGBResult);
                ServerWrapper.WarningOutputColor = System.Drawing.Color.FromArgb(1, ColorPicker.FinalRGBResult.R, ColorPicker.FinalRGBResult.G, ColorPicker.FinalRGBResult.B);
                ServerWrapper.Save();
            }
        }

        private void ErrorOutputColor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ColorPicker.DialogResult == true)
            {
                ErrorOutputColor.Fill = new SolidColorBrush(ColorPicker.FinalRGBResult);
                ServerWrapper.ErrorOutputColor = System.Drawing.Color.FromArgb(1, ColorPicker.FinalRGBResult.R, ColorPicker.FinalRGBResult.G, ColorPicker.FinalRGBResult.B);
                ServerWrapper.Save();
            }
        }

        private void ShowWarningOutput_Checked(object sender, RoutedEventArgs e)
        {
            WarningOutputColor.IsEnabled = true;
            ServerWrapper.ShowWarningOutput = true;
            ServerWrapper.Save();
        }

        private void ShowWarningOutput_Unchecked(object sender, RoutedEventArgs e)
        {
            WarningOutputColor.IsEnabled = false;
            ServerWrapper.ShowWarningOutput = false;
            ServerWrapper.Save();
        }

        private void ShowErrorOutput_Checked(object sender, RoutedEventArgs e)
        {
            ErrorOutputColor.IsEnabled = true;
            ServerWrapper.ShowErrorOutput = true;
            ServerWrapper.Save();
        }

        private void ShowErrorOutput_Unchecked(object sender, RoutedEventArgs e)
        {
            ErrorOutputColor.IsEnabled = false;
            ServerWrapper.ShowErrorOutput = false;
            ServerWrapper.Save();
        }
    }
}
