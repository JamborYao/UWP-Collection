using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ListViewMulitySelect : Page
    {
        public ListViewMulitySelect()
        {
            this.InitializeComponent();
            listView.ItemsSource = new List<string> { "a", "b", "c" };

        }
        private void Grid_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Grid grid = sender as Grid;
            string s = grid.DataContext as string; //this is the data object in the ItemsSource of the ListView
            if (s == "a" || s == "c") //select first and last
            {
                ListViewItem lvi = listView.ContainerFromItem(s) as ListViewItem;
                if (lvi != null)
                {
                    lvi.IsSelected = true;
                }
            }
        }
    }
   
}
