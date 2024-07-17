using LightSwitch.HotKey;
using System;
using System.Messaging;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace LightSwitch.Windows
{
    public partial class MainWindow : Window
    {
        private HotkeyManager _hotkeyManager;
        public MainWindow()
        {
            _hotkeyManager = new HotkeyManager(this, () => { MessageBox.Show("Test!"); });
            this.InitializeComponent();

        }

        // Header
        private void ExitButton_Click(object sender, RoutedEventArgs e) => _hotkeyManager.RegisterHotKey();
        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e) => this.DragMove();

        // Body
    }
}
