using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Collection.Models
{
    public class User : INotifyPropertyChanged
    {
        private string name;
        public bool is_Male { get; set; }
        public string ImageURL { get; set; }
        public string Name { get { return name; } set { this.name = value; this.NotifyPropertyChanged(); } }
        public string Address { get; set; }
        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Users
    {
        public Users()
        {
            items = new ObservableCollection<User>();
            items.Add(new User { Name = "phone", Address = "wuxi", Age = 28, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
            items.Add(new User { Name = "phone1", Address = "wuxi", Age = 30, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
            items.Add(new User { Name = "phone2", Address = "wuxi", Age = 29, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });

            items.Add(new User { Name = "phone", Address = "suzhou", Age = 28, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
            items.Add(new User { Name = "phone1", Address = "suzhou", Age = 30, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
            items.Add(new User { Name = "phone2", Address = "suzhou", Age = 29, ImageURL = "ms-appx:///Assets/StoreLogo.png", is_Male = true });
        }

        public ObservableCollection<User> items;
    }
}