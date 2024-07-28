using LightSwitch.HotKey;
using System;
using System.Messaging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace LightSwitch.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            (Application.Current as App).HKManager = new HotkeyManager(this, () => { MessageBox.Show("Success!"); });
            this.InitializeComponent();
        }

            

        // Header
        private void ExitButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e) => this.DragMove();

        // Body
        
    }
}
