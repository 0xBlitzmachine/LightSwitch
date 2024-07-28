using LightSwitch.HotKey;
using LightSwitch.Windows;
using System.Runtime.CompilerServices;
using System.Windows;

namespace LightSwitch
{
    public partial class App : Application
    {
        public HotkeyManager HKManager {  get; set; }
    }
}
