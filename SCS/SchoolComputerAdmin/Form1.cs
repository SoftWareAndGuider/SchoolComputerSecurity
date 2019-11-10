using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace SchoolComputerAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetImage_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(loop));
            thread.Start();
        }
        private void loop()
        {
            WebClient client = new WebClient();
            string download = client.DownloadString("JSON Server1");
            JObject jObject = JObject.Parse(download);
            Bitmap bitmap = Base64ToBitmap(jObject["Computer"].ToString());
            pictureBox1.Image = bitmap;
        }
        private Bitmap Base64ToBitmap(string base64)
        {
            StringBuilder SbText = new StringBuilder(base64, base64.Length);
            SbText.Replace("\r\n", string.Empty);
            SbText.Replace(" ", string.Empty);
            byte[] bitmapdata = Convert.FromBase64String(SbText.ToString());
            MemoryStream ms = new MemoryStream(bitmapdata);
            Bitmap bitmap = new Bitmap((Bitmap)Image.FromStream(ms));
            return bitmap;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GetImage.Enabled = false;
        }
    }
}
