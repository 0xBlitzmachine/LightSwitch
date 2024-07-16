using LightSwitch.HotKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LightSwitch.UserControls
{
    public partial class EasyMode : UserControl
    {
        private HotkeyManager _hotkeyManager;
        public EasyMode()
        {
            //this.Initialized += EasyMode_Initialized;
            this.InitializeComponent();
        }

        /*
        private void EasyMode_Initialized(object sender, EventArgs e)
        {
            Window window = Window.GetWindow(this);
            _hotkeyManager = new HotkeyManager(window);

            string result = string.Empty;
            
            switch (_hotkeyManager.RegisterHotKey())
            {
                case true: result = "Success"; break;
                case false: result = "Failed"; break;
            }

            MessageBox.Show($"RegisterHotkey -> {result}");
        }
        */
        
    }
}
