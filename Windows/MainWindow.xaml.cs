using System.Windows;
using System.Windows.Input;

namespace LightSwitch.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
        private void ExitButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
