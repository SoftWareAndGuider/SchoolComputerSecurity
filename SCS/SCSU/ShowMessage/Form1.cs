using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowMessage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText("Program\\Message.txt");
            string[] split = text.Split('\n');
            if (split.Length > 4) message.ScrollBars = ScrollBars.Vertical;
            foreach (string a in split)
            {
                message.Text += a + "\r\n";
            }
            notifyIcon1.BalloonTipText = "새로운 메세지가 있습니다.";
            notifyIcon1.BalloonTipTitle = "메세지 도착";
            notifyIcon1.ShowBalloonTip(500);
            System.IO.File.Delete("Program\\Message.txt");
        }
    }
}
