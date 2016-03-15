using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_Collection.Librarys;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Collection.Scenario
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Storyboard : Page
    {
        public static StackPanel mainPanel;
        public Storyboard()
        {
           
     
            this.InitializeComponent();
            Display.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/en/thumb/3/37/Jumpman_logo.svg/1024px-Jumpman_logo.svg.png"));


            Display2.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/en/thumb/3/37/Jumpman_logo.svg/1024px-Jumpman_logo.svg.png"));
            mainPanel = mystack;
        }
        Library Library = new Library();

        private void Go_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Display.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/en/thumb/3/37/Jumpman_logo.svg/1024px-Jumpman_logo.svg.png"));
            }
        }

        private void Pitch_Click(object sender, RoutedEventArgs e)
        {
            Library.Rotate("X", ref Display);
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            Library.Rotate("Y", ref Display2);
        }

        private void Yaw_Click(object sender, RoutedEventArgs e)
        {
            Library.Rotate("Z", ref Display);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //  myframe.Navigate(typeof(view1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(view1));
        }


    }
}
