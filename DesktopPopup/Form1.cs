using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace DesktopPopup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DateTime dt1 = Convert.ToDateTime("11:30");

            Win32.SetWindowPos(this.Handle, 100, Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height - 30, 50, 50, 1);//设置弹出位置
            Win32.AnimateWindow(this.Handle, 500, Win32.AW_VER_NEGATIVE);//设置弹出的动作
            this.label1.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");// "宽度：" + this.Width;
            this.label2.Text = dt1.CompareTo(DateTime.Now).ToString();// "高度：" + this.Height;
            //this.label2.Text.( "PopUp", "1");

        }

        public class Win32
        {
            public const Int32 AW_HOR_POSITIVE = 0x00000001;
            public const Int32 AW_HOR_NEGATIVE = 0x00000002;
            public const Int32 AW_VER_POSITIVE = 0x00000004;
            public const Int32 AW_VER_NEGATIVE = 0x00000008;
            public const Int32 AW_CENTER = 0x00000010;
            public const Int32 AW_HIDE = 0x00010000;
            public const Int32 AW_ACTIVATE = 0x00020000;
            public const Int32 AW_SLIDE = 0x00040000;
            public const Int32 AW_BLEND = 0x00080000;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool AnimateWindow(
                IntPtr hwnd,  //  handle  to  window  
                int dwTime,  //  duration  of  animation  
                int dwFlags  //  animation  type  
            );
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool SetWindowPos(
                IntPtr hwnd,
                int hWndInsertAfter,
                int x,
                int y,
                int cx,
                int cy,
                int wFlags
            );

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();//Close Hide
        }

    }
}
