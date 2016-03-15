using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
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
    public sealed partial class ADAuth : Page
    {
        private const string tenant = "karentest.onmicrosoft.com";
        private const string authority = "https://login.microsoftonline.com/" + tenant;
        private const string ClientID = "1e5eb5cb-2050-43f0-9bbd-7f5220cb149f";
        private const string resource = "https://karentest.onmicrosoft.com/APIServer";
        public ADAuth()
        {
            this.InitializeComponent();
            SignIn();
        }
        private async void SignIn()
        {

            WebAccountProvider wap = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://login.microsoft.com", authority);
            // WebAccount account = await WebAuthenticationCoreManager.FindAccountAsync(wap, "bc4a5ece-cff5-4110-abdc-9b9397e64960");
            WebTokenRequest wtr = new WebTokenRequest(wap, string.Empty, ClientID);
            wtr.Properties.Add("resource", resource);
            var url = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().Host;

            WebTokenRequestResult wtrr = await WebAuthenticationCoreManager.RequestTokenAsync(wtr);
            if (wtrr.ResponseStatus == WebTokenRequestStatus.Success)
            {
                string token = wtrr.ResponseData[0].Token;
                tokenTB.Text = token;
            }
        }
    }
}
