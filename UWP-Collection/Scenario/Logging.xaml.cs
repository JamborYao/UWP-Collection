using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Collection.Scenario
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Logging : Page
    {
        public Logging()
        {
            this.InitializeComponent();
            Init();
        }
        public async void Init()
        {
            logFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("log",CreationCollisionOption.OpenIfExists);
            channel = new LoggingChannel("jamborsamplelog");
            filesession = new FileLoggingSession("filesession");
            filesession.AddLoggingChannel(channel, LoggingLevel.Error);
            session = new LoggingSession("jamborsession");
            session.AddLoggingChannel(channel, LoggingLevel.Critical);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            channel.LogMessage("this is my first log information in uwp",LoggingLevel.Critical);           
           
            StorageFile file = await session.SaveToFileAsync(logFolder, "mylog.etl");


        }
        private LoggingChannel channel;
        private StorageFolder logFolder;
        private LoggingSession session;
        private FileLoggingSession filesession;

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            channel.LogMessage("this is my filesession log",LoggingLevel.Error);
            var logfile = await filesession.CloseAndSaveToFileAsync();
            await logfile.MoveAsync(logFolder, "fileSession.etl");
        }
        public void DisableEnableToggle()
        {
            if (session != null)
            {
                session.Dispose();
            }
            else
            {
                session = new LoggingSession("jamborsession");
                session.AddLoggingChannel(channel, LoggingLevel.Critical);
            }
        }
    }
}
