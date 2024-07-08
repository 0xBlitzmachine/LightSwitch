using System.Windows;
using System.Windows.Input;

namespace LightSwitch.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow() => this.InitializeComponent();

        // Header
        private void ExitButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void HeaderGrid_MouseDown(object sender, MouseButtonEventArgs e) => this.DragMove();

        // Body
    }
}
