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
    public sealed partial class Dialog : Page
    {
        public Dialog()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog("show message!", "title");
          
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Yes",new Windows.UI.Popups.UICommandInvokedHandler((u)=> {
                lbContent.Text = $"Yes clieked!";
            })));
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("No",new Windows.UI.Popups.UICommandInvokedHandler((u)=> {
                lbContent.Text = $"No clieked!";
            })));

            await dialog.ShowAsync();

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //var dialog = new ContentDialog()
            //{
            //    Title = "title!",
            //};
            //var panel = new StackPanel();

            //panel.Children.Add(new TextBlock
            //{
            //    Text = "Aliquam laoreet magna sit amet mauris iaculis ornare. " +
            //                "Morbi iaculis augue vel elementum volutpat.",
            //    TextWrapping = TextWrapping.Wrap,
            //});
            //dialog.Content = panel;
            //dialog.PrimaryButtonText = "OK";
            //dialog.SecondaryButtonText = "Cancle";
            //dialog.PrimaryButtonClick += (u,x)=> {
            //    lbContent.Text = "primary button clicked!";
            //};

            //await dialog.ShowAsync();
            
            mycontentDialog.PrimaryButtonText = "OK";
            mycontentDialog.SecondaryButtonText = "Cancle";
            mycontentDialog.PrimaryButtonClick += (u, x) =>
            {
                lbContent.Text = "primary button clicked!";
            };
            await mycontentDialog.ShowAsync();
        }

      
    }
}
