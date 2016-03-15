using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System;
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
    public sealed partial class ListviewGroup : Page
    {
        public ListviewGroup()
        {
            this.InitializeComponent();
            Models.User item = new Models.User();
#if NETFX_CORE
            item = new Models.User { Name = "phone", Address = "wuxi" + (new Random().Next(0, 100)), Age = 28, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true };
#else
               item = new Models.User { Name = "windows", Address = "wuxi", Age = 28 ,ImageURL="ms-appx:///Assets/StoreLogo.png"};

#endif
            items = new ObservableCollection<Models.User>();
            items.Add(new Models.User { Name = "phone", Address = "wuxi", Age = 28, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
            items.Add(new Models.User { Name = "phone1", Address = "wuxi", Age = 30, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
            items.Add(new Models.User { Name = "phone2", Address = "wuxi", Age = 29, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });

            items.Add(new Models.User { Name = "phone", Address = "suzhou", Age = 28, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
            items.Add(new Models.User { Name = "phone1", Address = "suzhou", Age = 30, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
            items.Add(new Models.User { Name = "phone2", Address = "suzhou", Age = 29, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });

            var c = this.groupUser;
            gviewNavigation.ItemsSource = items;
        }
        private IOrderedEnumerable<IGrouping<string, Models.User>> genres;
        public IOrderedEnumerable<IGrouping<string, Models.User>> groupUser
        {
            get
            {
                this.genres = from c in items
                              group c by c.Address into b
                              orderby b.Key
                              select b;
                return this.genres;
            }
        }


        public static readonly StorageCredentials cred = new StorageCredentials("willshao", "tgbo/iCw6KMVBSH1T7wrpT1bjoYtWJXGjYU/xnTKSbeg2uUlzelekbcfTrSH3KRGp+Gkwkfbnlhs7Pl2gKn9nw==");
        public async void downloadBlob()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(cred, true);



            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();



            // Retrieve reference to a previously created container.                        

            CloudBlobContainer container = blobClient.GetContainerReference("test");
            CloudBlockBlob blob = container.GetBlockBlobReference("sample.txt");

            StorageFile file = await Windows.Storage.ApplicationData.Current.TemporaryFolder.CreateFileAsync($"sample{((new Random()).Next(1, 1000))}.txt");
            using (Stream fileStream = await file.OpenStreamForWriteAsync())
            {
                Stream saveStr = new System.IO.MemoryStream();
                IOutputStream winStr = System.IO.WindowsRuntimeStreamExtensions.AsOutputStream(saveStr);

                await blob.DownloadToStreamAsync(winStr);
                saveStr.Position = 0;
                saveStr.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        public string append { get; set; }



        public ObservableCollection<Models.User> items;

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //downloadBlob();
            //items.RemoveAt(0);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private async void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Create destination file and obtain sharing token
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Cropped.jpg", CreationCollisionOption.ReplaceExisting);
            var token = SharedStorageAccessManager.AddFile(file);

            // Specify the app to launch using LaunchUriForResults
            var options = new LauncherOptions();
            options.TargetApplicationPackageFamilyName = "Microsoft.Windows.Photos_8wekyb3d8bbwe";

            // Specify all the parameters
            var parameters = new ValueSet();
            parameters.Add("CropWidthPixels", 500);
            parameters.Add("CropHeightPixels", 500);
            parameters.Add("EllipticalCrop", true);
            parameters.Add("ShowCamera", false);
            parameters.Add("DestinationToken", token);

            // Launches the app and wait for results
            var result = await Launcher.LaunchUriAsync(new Uri("ms-settings://network/wifi"), options, parameters);
            // Check if the user has really cropped the picture
            //if (result.Status == LaunchUriStatus.Success && result.Result != null)
            //{
            //    // Loads the picture
            //    //var stream = await file.OpenReadAsync();
            //    //var bitmap = new BitmapImage();
            //    //await bitmap.SetSourceAsync(stream);

            //    // Set the picture as Source of an Image control
            //   // Preview.Source = bitmap;
            //}

        }

        private void ListView_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }
        public void TraceMessage(string message,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
           [System.Runtime.CompilerServices.CallerMemberName] string propertyname = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Debug.WriteLine("message: " + message);
            Debug.WriteLine("member name: " + memberName);
            Debug.WriteLine("source file path: " + sourceFilePath);
            Debug.WriteLine("source line number: " + sourceLineNumber);
            Debug.WriteLine("source line number: " + propertyname);
        }

    }

}