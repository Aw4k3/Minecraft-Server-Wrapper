using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Minecraft_Server_Wrapper
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        public ColorPicker()
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

        ColorConverter colorConverter = new ColorConverter();
        public Color FinalRGBResult;

        private void Solid_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                PreviousColor.Background = CurrentColor.Background;
                //Solve value for end Saturation Slider Color 
                Color SatSliderStartColor = Color.FromRgb(Convert.ToByte((Solid_ValSlider.Value / 100) * 255), Convert.ToByte((Solid_ValSlider.Value / 100) * 255), Convert.ToByte((Solid_ValSlider.Value / 100) * 255));
                Color SatSliderEndColor = colorConverter.HsvToRgb(Solid_HueSlider.Value, 1, Solid_ValSlider.Value / 100);
                Color ValSliderEndColor = colorConverter.HsvToRgb(Solid_HueSlider.Value, Solid_SatSlider.Value / 100, 1);
                FinalRGBResult = colorConverter.HsvToRgb(Solid_HueSlider.Value, Solid_SatSlider.Value / 100, Solid_ValSlider.Value / 100);

                //Apply Saturation Slider Color
                LinearGradientBrush SatSliderBrush = new LinearGradientBrush(SatSliderStartColor, SatSliderEndColor, 0)
                {
                    ColorInterpolationMode = ColorInterpolationMode.ScRgbLinearInterpolation
                };
                Solid_SatSlider.Background = SatSliderBrush;

                //Apply Saturation Slider Color
                LinearGradientBrush ValSliderBrush = new LinearGradientBrush(Color.FromRgb(0, 0, 0), ValSliderEndColor, 0)
                {
                    ColorInterpolationMode = ColorInterpolationMode.ScRgbLinearInterpolation
                };
                Solid_ValSlider.Background = ValSliderBrush;

                //Color Preview
                CurrentColor.Background = new SolidColorBrush(FinalRGBResult);

                //Display Info
                HueValue.Content = Math.Round(Solid_HueSlider.Value);
                SatValue.Content = Math.Round(Solid_SatSlider.Value);
                ValValue.Content = Math.Round(Solid_ValSlider.Value);
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void PreviousColor_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CurrentColor.Background = PreviousColor.Background;
        }
    }
}
