using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Collection.Models
{
    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
    public class Scenarios
    {
        public Scenarios()
        {
            scenarios = new List<Scenario>();
            scenarios.Add(new Scenario() {Title="ADAuth", ClassType=typeof(UWP_Collection.Scenario.ADAuth) });
            scenarios.Add(new Scenario() { Title = "DeviceInfo", ClassType = typeof(UWP_Collection.Scenario.DeviceInfo) });
            scenarios.Add(new Scenario() { Title = "ListviewGroup", ClassType = typeof(UWP_Collection.Scenario.ListviewGroup) });
            scenarios.Add(new Scenario() { Title = "Storyboard", ClassType = typeof(UWP_Collection.Scenario.Storyboard) });
            scenarios.Add(new Scenario() { Title = "Dialog", ClassType = typeof(UWP_Collection.Scenario.Dialog) });
            scenarios.Add(new Scenario() { Title = "MyLayout", ClassType = typeof(UWP_Collection.Scenario.MyLayout) });
            scenarios.Add(new Scenario() { Title = "File", ClassType = typeof(UWP_Collection.Scenario.FileHandle) });
            scenarios.Add(new Scenario() { Title = "xBind", ClassType = typeof(UWP_Collection.Scenario.xBind) });
            scenarios.Add(new Scenario() { Title = "Logging", ClassType = typeof(UWP_Collection.Scenario.Logging) });
        }
        public List<Scenario> scenarios { get; set; }
    }
}
