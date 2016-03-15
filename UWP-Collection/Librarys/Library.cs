using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Collection.Scenario;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace UWP_Collection.Librarys
{
    public class Library
    {
        private bool rotating = false;
        private Windows.UI.Xaml.Media.Animation.Storyboard rotation = new Windows.UI.Xaml.Media.Animation.Storyboard();

        public void Rotate(string axis, ref Image target)
        {
            if (rotating)
            {
                rotation.Stop();
                rotating = false;
            }
            else
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0.0;
                animation.To = 360.0;
                animation.BeginTime = TimeSpan.FromSeconds(1);
                Windows.UI.Xaml.Media.Animation.Storyboard.SetTarget(animation, target);
                Windows.UI.Xaml.Media.Animation.Storyboard.SetTargetProperty(animation, "(UIElement.Projection).(PlaneProjection.Rotation" + axis + ")");
                rotation.Children.Clear();
                rotation.Children.Add(animation);
                rotation.SetValue(Windows.UI.Xaml.Media.Animation.Storyboard.TargetNameProperty, target.Name);
                rotation.Begin();
                rotation.Completed += Rotation_Completed;
                rotating = true;
            }
        }

        private void Rotation_Completed(object sender, object e)
        {
            var control = (sender as Windows.UI.Xaml.Media.Animation.Storyboard).GetValue(Windows.UI.Xaml.Media.Animation.Storyboard.TargetNameProperty);
            List<Image> list = new List<Image>();
            Scenario.Storyboard.mainPanel.FindName(control.ToString());
        }

    }
}
