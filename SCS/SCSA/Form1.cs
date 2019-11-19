﻿using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Text;

namespace SCSA
{
    public partial class Form1 : Form
    {
        bool looping = true;
        int monitor = 1;
        string image, mgr;
        string mac;
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
            WebClient client = new WebClient();
            mac = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
            try
            {
                string[] split = File.ReadAllLines("url.txt");
                image = $"{split[0]}";
                MessageBox.Show(image);
                mgr = $"{split[1]}";
            }
            catch
            {
                SCSAPopup popup = new SCSAPopup();
                popup.ShowDialog();
            }
            Thread thread = new Thread(new ThreadStart(loop));
            thread.Start();
        }
        private void loop()
        {
            while (looping)
            {
                try
                {
                    WebClient client = new WebClient();
                    string download = client.DownloadString(image);
                    string[] split = download.Split(';');
                    if (split.Length == 1)
                    {
                        monitor = 1;
                        번모니터ToolStripMenuItem1.Enabled = false;
                        번모니터ToolStripMenuItem1.Checked = false;
                        번모니터ToolStripMenuItem1.Text = "";
                        번모니터ToolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        번모니터ToolStripMenuItem1.Enabled = true;
                        번모니터ToolStripMenuItem1.Text = "2번 모니터";
                    }
                    bitmap = new Bitmap((Bitmap)Image.FromFile("1px.png"));
                    if (monitor == 1)
                    {
                        bitmap = Base64ToBitmap(split[0]);
                    }
                    else
                    {
                        bitmap = Base64ToBitmap(split[1]);
                    }
                    pictureBox1.Image = bitmap;
                }
                catch
                {
                }
                Thread.Sleep(250);
            }
        }
        private Bitmap Base64ToBitmap(string base64)
        {
            StringBuilder SbText = new StringBuilder(base64, base64.Length);
            SbText.Replace("\r\n", string.Empty);
            SbText.Replace(" ", string.Empty);
            byte[] bitmapdata = Convert.FromBase64String(SbText.ToString());
            MemoryStream ms = new MemoryStream(bitmapdata);
            Bitmap asdf = new Bitmap((Bitmap)Image.FromStream(ms));
            return asdf;
        }
        private void 번모니터ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monitor = 1;
            번모니터ToolStripMenuItem.Checked = true;
            번모니터ToolStripMenuItem1.Checked = false;
        }

        private void 번모니터ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            monitor = 2;
            번모니터ToolStripMenuItem1.Checked = true;
            번모니터ToolStripMenuItem.Checked = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            looping = false;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("교실 컴퓨터의 전원을 종료하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                WebClient client = new WebClient();
                client.DownloadString($"{mgr}/shutdown");
            }
        }

        private void 다시시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("교실 컴퓨터를 다시 시작하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                WebClient client = new WebClient();
                client.DownloadString($"{mgr}/restart");
            }
        }

        private void 절전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("교실 컴퓨터를 절전 모드로 전환 하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                WebClient client = new WebClient();
                client.DownloadString($"{mgr}/shutdown");
            }
        }

        private void 사진찍기개발중ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            bitmap.Save($"");
        }

        private void 메세지전송ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCSASandMessage message = new SCSASandMessage();
            message.url = mgr;
            message.ShowDialog();
        }
    }
}
