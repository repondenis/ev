using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EVotingProject.Helpers
{
    public static class KeyboardHelper
    {
        [DllImport("user32.dll")]
        static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


        public static void KeyDown(System.Windows.Forms.Keys key)
        {
            keybd_event((byte)key, 0, 0, 0);
        }

        public static void KeyUp(System.Windows.Forms.Keys key)
        {
            keybd_event((byte)key, 0, 0x7F, 0);
        }
    }
}