﻿using System;
using System.Net;
using System.IO.Compression;
using System.Windows.Forms;
using System.IO;

namespace SCSUUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
            ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            re:
            try
            {
                hide();
                WebClient client = new WebClient();
                string programpath = @"Program";
                Directory.Delete(programpath, true);
                Directory.CreateDirectory(programpath);
                string ftpPath = "ftp server url"; //Your server file url
                string targetPath = @"Program\SCSU.zip";

                string userID = "ftp id"; //Your server id
                string password = "ftp password"; //Your server password
                client.Credentials = new NetworkCredential(userID, password);
                client.DownloadFile(ftpPath, targetPath);
                System.Threading.Thread.Sleep(100);
                ZipFile.ExtractToDirectory($@"{programpath}\SCSU.zip", programpath);
            }
            catch { System.Threading.Thread.Sleep(100); goto re; }
            try
            {
                System.Diagnostics.Process.Start(@"Program\SCSU.exe");
            }
            catch
            {
                try
                {
                    System.Diagnostics.Process.Start(@"C:\SCS\Program\SCSU.exe");
                }
                catch
                {
                    goto re;
                }
            }
            Application.Exit();
        }
        private void hide()
        {
            Hide();
        }
    }
}
