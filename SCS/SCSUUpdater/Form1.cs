using System;
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
            try
            {
                WebClient client = new WebClient();
                string programpath = @"Program";
                Directory.Delete(programpath, true);
                Directory.CreateDirectory(programpath);
                string ftpPath = "ftp://server.noeul.xyz/fileshare/SCS/SCSU.zip";
                string targetPath = @"Program\SCSU.zip";
                string userID = "fileshareftp";
                string password = "noeulfile1412!";
                client.Credentials = new NetworkCredential(userID, password);
                client.DownloadFile(ftpPath, targetPath);
                System.Threading.Thread.Sleep(100);
                ZipFile.ExtractToDirectory($@"{programpath}\SCSU.zip", programpath);
            }
            catch { }
            System.Diagnostics.Process.Start(@"Program\SCSU.exe");
            Application.Exit();
        }
    }
}
