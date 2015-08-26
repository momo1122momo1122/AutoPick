using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace AutoPick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out Rectangle rect);
        
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
       
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }

        }

        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }
        Bitmap champion_jpg;
        struct loc
        {
            public int top { set; get; }
            public int left { set; get; }
            public int height { set; get; }
            public int width { set; get; }
        }


        public static void SetCursorPosition(int X, int Y)
        {
            SetCursorPos(X, Y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0)
                ;
        }

        public static Bitmap PrintWindow(IntPtr hwnd)
        {
            Rectangle rect = new Rectangle();
            GetWindowRect(hwnd, out rect);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hwnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }


        loc champion;
        loc chat;
        loc sel;
        loc send;

        private void timer_Tick(object sender, EventArgs e)
        {
            IntPtr hwnd = Process.GetProcessesByName("LolClient")[0].MainWindowHandle;
            Rectangle rect = new Rectangle();
            GetWindowRect(hwnd, out rect);
 

            Rectangle cropRect = new Rectangle(
                champion.left,
                champion.top,
                champion.width,
                champion.height
            );

            Bitmap bmp = PrintWindow(hwnd);
            Bitmap target = new Bitmap(champion.width, champion.height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(bmp, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }

            float cmp = Funkcje.Compare(target, champion_jpg);
            label3.Text = cmp.ToString();

            if (cmp <= 10)
            {
                timer.Enabled = false;

                Funkcje.SetCursorPos(rect.Left + champion.left + (champion.width / 2), rect.Top + champion.top + (champion.height / 2));
                MouseEvent(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp);
                SendKeys.Send(textBox_champion.Text);

 

                Funkcje.SetCursorPos(rect.Left + chat.left + (chat.width / 2), rect.Top + chat.top + (chat.height / 2));
                MouseEvent(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp);
                SendKeys.Send(textBox_chat.Text);

                Funkcje.SetCursorPos(rect.Left + send.left + (send.width / 2), rect.Top + send.top + (send.height / 2));
                MouseEvent(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp);

                Funkcje.SetCursorPos(rect.Left + sel.left + (sel.width / 2), rect.Top + sel.top + (sel.height / 2));
                System.Threading.Thread.Sleep(100);
                MouseEvent(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
            IniFile ini = new IniFile(path);
            champion.left = Convert.ToInt32(ini.IniReadValue("champion", "left"));
            champion.top = Convert.ToInt32(ini.IniReadValue("champion", "top"));
            champion.width = Convert.ToInt32(ini.IniReadValue("champion", "width"));
            champion.height = Convert.ToInt32(ini.IniReadValue("champion", "height"));

            chat.left = Convert.ToInt32(ini.IniReadValue("chat", "left"));
            chat.top = Convert.ToInt32(ini.IniReadValue("chat", "top"));
            chat.width = Convert.ToInt32(ini.IniReadValue("chat", "width"));
            chat.height = Convert.ToInt32(ini.IniReadValue("chat", "height"));

            sel.left = Convert.ToInt32(ini.IniReadValue("sel", "left"));
            sel.top = Convert.ToInt32(ini.IniReadValue("sel", "top"));
            sel.width = Convert.ToInt32(ini.IniReadValue("sel", "width"));
            sel.height = Convert.ToInt32(ini.IniReadValue("sel", "height"));

            send.left = Convert.ToInt32(ini.IniReadValue("send", "left"));
            send.top = Convert.ToInt32(ini.IniReadValue("send", "top"));
            send.width = Convert.ToInt32(ini.IniReadValue("send", "width"));
            send.height = Convert.ToInt32(ini.IniReadValue("send", "height"));

            using (Bitmap bmptmp = Bitmap.FromFile("champion.jpg") as Bitmap)
            {
                champion_jpg = new Bitmap(bmptmp);
            }

            if (button1.Text == "Auto Pick start")
            {
                button1.Text = "Auto Pick stop";
                timer.Enabled = true;
            }
            else
            {
                button1.Text = "Auto Pick start";
                timer.Enabled = false;
            }
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            timer.Stop();
            Form2 fm2 = new Form2();
            fm2.ShowDialog();

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            


        }
    }
}
