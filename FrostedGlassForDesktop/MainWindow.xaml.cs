using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wallpaper;

namespace FrostedGlassForDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var screenwidth = (SystemParameters.PrimaryScreenWidth);
            var screenheight = (SystemParameters.PrimaryScreenHeight);

            wallpaper_instance.Source = Screenshot.CopyScreen();
            wallpaper_instance.Width = screenwidth;
            wallpaper_instance.Height = screenheight;
            RenderOptions.SetBitmapScalingMode(wallpaper_instance, BitmapScalingMode.LowQuality);

            canvas.Children.Add(wallpaper_instance);

            BlurBitmapEffect myBlurEffect = new BlurBitmapEffect();

            // Set the Radius property of the blur. This determines how 
            // blurry the effect will be. The larger the radius, the more
            // blurring. 
            myBlurEffect.Radius = 15;

            // Set the KernelType property of the blur. A KernalType of "Box"
            // creates less blur than the Gaussian kernal type.
            myBlurEffect.KernelType = KernelType.Box;

            // Apply the bitmap effect to the Button.
            wallpaper_instance.BitmapEffect = myBlurEffect;
        }


        private Image wallpaper_instance = new Image();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            UpdatePosition();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            var left = Application.Current.MainWindow.Left;
            var top = Application.Current.MainWindow.Top;

            Canvas.SetLeft(wallpaper_instance, left * -1);
            Canvas.SetTop(wallpaper_instance, top * -1);
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            UpdatePosition();
        }
    }
}
