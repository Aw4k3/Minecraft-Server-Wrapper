using System;
using System.Windows;
using System.Windows.Input;

namespace Minecraft_Server_Wrapper
{
    /// <summary>
    /// Interaction logic for ServerPropertiesManager.xaml
    /// </summary>
    public partial class ServerPropertiesManager : Window
    {
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
    }
}
