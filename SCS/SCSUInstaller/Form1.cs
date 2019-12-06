using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCSUInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            TaskList.SetItemChecked(0, true);
            try
            {
                Directory.Delete("C:\\SCS", true);
                Directory.CreateDirectory("C:\\SCS");
            }
            catch
            {
                Directory.CreateDirectory("C:\\SCS");
            }
            TaskList.SetItemChecked(1, true);
            progressBar1.Value = 1;

            WebClient client = new WebClient();

            string programpath = @"C:\SCS";
            string ftpPath = "ftp://fileshareftp@nas.noeul.xyz/fileshare/SCS/SCSUUpdater.zip";
            string targetPath = @"C:\SCS\SCSUUpdater.zip";
            string userID = "fileshareftp";
            string password = "noeulfile1412!";
            client.Credentials = new NetworkCredential(userID, password);
            client.DownloadFile(ftpPath, targetPath);
            TaskList.SetItemChecked(2, true);
            progressBar1.Value = 2;

            ZipFile.ExtractToDirectory($@"{programpath}\SCSUUpdater.zip", programpath);
            TaskList.SetItemChecked(3, true);
            progressBar1.Value = 3;
            var reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); 
            reg.SetValue("SCSU", @"C:\SCS\SCSUUpdater.exe");
            TaskList.SetItemChecked(4, true);
            progressBar1.Value = 4;
            TaskList.SetItemChecked(5, true);
            progressBar1.Value = 5;
            button1.Enabled = true;
            if (DialogResult.Yes == MessageBox.Show("설치가 완료되었습니다. 다시 시작 하시겠습니까?", "리부팅", MessageBoxButtons.YesNo))
            {
                Process.Start("shutdown.exe", "/r /t 0");
            }
        }
    }
}
