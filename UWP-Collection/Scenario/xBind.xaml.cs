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
    public sealed partial class xBind : Page
    {
        public xBind()
        {
            this.InitializeComponent();
            users.Add(new User.Admin() { Role = "jone" });
            users.Add(new User.Admin() { Role = "tom" });
            users.Add(new User.Admin() { Role = "jack" });
            users.Add(new User.Admin() { Role = "daniel" });
            news.Add(new News { Title = "hello", Description = "hello describe" });
            news.Add(new News { Title = "greet", Description = "hello describe" });
            news.Add(new News { Title = "byes", Description = "hello describe" });
        }
        public List<User.Admin> users = new List<User.Admin>();
        public string test = "hello world!";
        public List<News> news = new List<News>();
    }
    public class User
    {
        public string Name { get; set; }
        public class Admin
        {
            public string Role { get; set; }
        }
    }
    public class News
    {
        public string Title { get; set; }
        public string  Description { get; set; }
    }
}
