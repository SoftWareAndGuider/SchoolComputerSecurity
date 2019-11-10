using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace SCSAUpdater
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
                if (client.DownloadString("JSON Server 1") != File.ReadAllText("version.json"))
                {
                    string programpath = @"..\Program";
                    Directory.Delete(programpath, true);
                    Directory.CreateDirectory(programpath);
                    string ftpPath = "FTP Server";
                    string targetPath = @"..\Program\SCSA.zip";
                    string userID = "updater";
                    string password = "update";
                    client.Credentials = new NetworkCredential(userID, password);
                    client.DownloadFile(ftpPath, targetPath);
                    System.Threading.Thread.Sleep(100);
                    ZipFile.ExtractToDirectory($@"{programpath}\SCSA.zip", programpath);
                    client.DownloadFile("JSON Server 1", "version.json");
                }
            }
            catch { }
            System.Diagnostics.Process.Start(@"..\Program\SCSA.exe");
            Application.Exit();
        }
    }
}
