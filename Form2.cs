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
    public partial class Form2 : Form
    {

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out Rectangle rect);

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        public Form2()
        {
            InitializeComponent();
            
        }

        Form3 formSet;
        bool move = false;
        Point locationClicked;
        IntPtr hwnd;
        Rectangle rect;
 
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

        struct loc
        {
            public int q { set; get; }
            public int w { set; get; }
            public int e { set; get; }
            public int r { set; get; }
        }


        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            locationClicked = new Point(e.Location.X, e.Location.Y);
            move = true;
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                IntPtr hwnd = Process.GetProcessesByName("LolClient")[0].MainWindowHandle;
                Rectangle rect = new Rectangle();
                GetWindowRect(hwnd, out rect);

                int x = formSet.Location.X + (e.X - locationClicked.X);
                int y = formSet.Location.Y + (e.Y - locationClicked.Y);

                formSet.Location = new Point(x, y);

                if ( ((x - rect.X > 1) && (x - rect.X < 4800)) &&
                     ((y - rect.Y > 1) && (y - rect.Y < 4800))
                    )
                {
                    this.numericUpDown_left.Value = x - rect.X;
                    this.numericUpDown_top.Value = y - rect.Y;
                }
            }
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            rect = new Rectangle();
            GetWindowRect(hwnd, out rect);
            formSet.Location = new Point(rect.X + Convert.ToInt32(numericUpDown_left.Value), rect.Y + Convert.ToInt32(numericUpDown_top.Value));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            rect = new Rectangle();
            GetWindowRect(hwnd, out rect);
            formSet.Location = new Point(rect.X + Convert.ToInt32(numericUpDown_left.Value), rect.Y + Convert.ToInt32(numericUpDown_top.Value));
        }


        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            rect = new Rectangle();
            GetWindowRect(hwnd, out rect);
            formSet.Size = new Size( Convert.ToInt32(numericUpDown_right.Value), Convert.ToInt32(numericUpDown_bottom.Value));
            formSet.Refresh();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            rect = new Rectangle();
            GetWindowRect(hwnd, out rect);
            formSet.Size = new Size(Convert.ToInt32(numericUpDown_right.Value), Convert.ToInt32(numericUpDown_bottom.Value));
            formSet.Refresh();
        }


        private void button_exit_Click(object sender, EventArgs e)
        {
            formSet.Close();
            Application.Exit();
        }

        private void button_set_champion_Click(object sender, EventArgs e)
        {
            int left = Convert.ToInt32(numericUpDown_left.Value);
            int top = Convert.ToInt32(numericUpDown_top.Value);
            int width = Convert.ToInt32(numericUpDown_right.Value);
            int height = Convert.ToInt32(numericUpDown_bottom.Value);

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
            IniFile ini = new IniFile(path);
            ini.IniWriteValue("champion", "left", left.ToString());
            ini.IniWriteValue("champion", "top", top.ToString());
            ini.IniWriteValue("champion", "width", width.ToString());
            ini.IniWriteValue("champion", "height", height.ToString());

            Rectangle cropRect = new Rectangle(
                left,
                top,
                width,
                height
                );

            Bitmap bmp = PrintWindow(hwnd);
            Bitmap target = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(bmp, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }

            target.Save("champion.jpg");

        }

        private void button_set_chat_Click(object sender, EventArgs e)
        {
            int left = Convert.ToInt32(numericUpDown_left.Value);
            int top = Convert.ToInt32(numericUpDown_top.Value);
            int width = Convert.ToInt32(numericUpDown_right.Value);
            int height = Convert.ToInt32(numericUpDown_bottom.Value);

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
            IniFile ini = new IniFile(path);
            ini.IniWriteValue("chat", "left", left.ToString());
            ini.IniWriteValue("chat", "top", top.ToString());
            ini.IniWriteValue("chat", "width", width.ToString());
            ini.IniWriteValue("chat", "height", height.ToString());

            Rectangle cropRect = new Rectangle(
                left,
                top,
                width,
                height
                );

            Bitmap bmp = PrintWindow(hwnd);
            Bitmap target = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(bmp, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }

            target.Save("chat.jpg");

        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            formSet = new Form3();
            formSet.Show();
            formSet.TopMost = true;
            
            try
            {
                hwnd = Process.GetProcessesByName("LolClient")[0].MainWindowHandle;
            }
            catch
            {
                label_log.Text = "Lol window not found";
            }

            rect = new Rectangle();

            formSet.MouseDown += new MouseEventHandler(this.Form3_MouseDown);
            formSet.MouseUp += new MouseEventHandler(this.Form3_MouseUp);
            formSet.MouseMove += new MouseEventHandler(this.Form3_MouseMove);

        }


     
        private void button1_Click(object sender, EventArgs e)
        {
            int left = Convert.ToInt32(numericUpDown_left.Value);
            int top = Convert.ToInt32(numericUpDown_top.Value);
            int width = Convert.ToInt32(numericUpDown_right.Value);
            int height = Convert.ToInt32(numericUpDown_bottom.Value);

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
            IniFile ini = new IniFile(path);
            ini.IniWriteValue("sel", "left", left.ToString());
            ini.IniWriteValue("sel", "top", top.ToString());
            ini.IniWriteValue("sel", "width", width.ToString());
            ini.IniWriteValue("sel", "height", height.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int left = Convert.ToInt32(numericUpDown_left.Value);
            int top = Convert.ToInt32(numericUpDown_top.Value);
            int width = Convert.ToInt32(numericUpDown_right.Value);
            int height = Convert.ToInt32(numericUpDown_bottom.Value);

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
            IniFile ini = new IniFile(path);
            ini.IniWriteValue("send", "left", left.ToString());
            ini.IniWriteValue("send", "top", top.ToString());
            ini.IniWriteValue("send", "width", width.ToString());
            ini.IniWriteValue("send", "height", height.ToString());
        }
    }
}
