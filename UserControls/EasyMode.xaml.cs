using LightSwitch.HotKey;
using LightSwitch.Windows;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LightSwitch.UserControls
{
    public partial class EasyMode : UserControl
    {
        public EasyMode() => this.InitializeComponent();

        private void SetHotkeyButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).HKManager.RegisterHotKey();
        }
    }
}
