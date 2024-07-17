using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Interop;

namespace LightSwitch.HotKey
{
    /* TODO */
    /*
     * - Pass functions trough constructor to pass it trough WndProc
     * - Function to set the current selected Key - UserController should use the instance of hotkey-manager of the Window it lives in.
     */
    public class HotkeyManager : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        // Import native functions from the win32 library

        // Private Properties
        private readonly Window _window;
        private HwndSource _hwndSource;
        private Action _hotkeyAction;
        private Key _currentHotkey = Key.T;
        private int _hotKeyId = 0;

        // Public Properties
        public Key CurrentHotkey {  
            get { return _currentHotkey; }
            set {
                _currentHotkey = value;
                if (!this.RegisterHotKey())
                {
                    UnregisterHotKey();
                    RegisterHotKey();
                }
                else RegisterHotKey();
            }
        }

        // Initialize window and its events to handle the hotkey
        public HotkeyManager(Window window, Action hotkeyAction)
        {
            _window = window;
            _hotkeyAction = hotkeyAction;

            _window.SourceInitialized += _window_SourceInitialized;
            _window.Closed += _window_Closed;
        }

        public bool RegisterHotKey() => RegisterHotKey(_hwndSource.Handle, _hotKeyId, 0x0000, KeyInterop.VirtualKeyFromKey(_currentHotkey));
        public bool UnregisterHotKey() => UnregisterHotKey(_hwndSource.Handle, _hotKeyId);


        // Window Events
        private void _window_Closed(object sender, EventArgs e) => Dispose();

        private void _window_SourceInitialized(object sender, EventArgs e)
        {
            var handle = new WindowInteropHelper(_window).Handle;
            _hwndSource = HwndSource.FromHwnd(handle);
            _hwndSource.AddHook(WndProc);
        }

        // Handle incoming messages to the window
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
        //https://learn.microsoft.com/de-de/windows/win32/inputdev/keyboard-input-notifications
        //Make sure to only react when it receives a window key input notification
            const int WM_HOTKEY = 0x0312;
            if (msg == WM_HOTKEY && wParam.ToInt32() == _hotKeyId)
            {
                _hotkeyAction();
                handled = true;
            }
            return IntPtr.Zero;
        }

        public void Dispose()
        {
            UnregisterHotKey(_hwndSource.Handle, _hotKeyId);
           _hwndSource?.RemoveHook(WndProc);
        }
    }
}

