using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AS
{
    public partial class Form1 : Form
    {
        bool looptrue = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            ShowInTaskbar = false;
            loop ();
        }
        private async void loop()
        {
            while(looptrue)
            {
                Hide();
                System.Diagnostics.Process[] scsu = System.Diagnostics.Process.GetProcessesByName("SCSU");
                if (scsu.Length <= 0)
                {
                    System.Diagnostics.Process.Start("SCSU.exe");
                    Application.Exit();
                }
                await Task.Delay(10000);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            looptrue = false;
        }
    }
}
