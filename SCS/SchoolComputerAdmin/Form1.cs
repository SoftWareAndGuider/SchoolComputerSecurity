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
        JObject setting = new JObject();
        bool looping = true;
        int monitor = 1;
        public Form1()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(loop));
            thread.Start();
        }
        private void loop()
        {
            while (looping)
            {
                WebClient client = new WebClient();
                string download = client.DownloadString("JSON Server 1");
                JObject jObject = JObject.Parse(download);
                if (jObject["Second"] == null)
                {
                    번모니터ToolStripMenuItem1.Enabled = false;
                    monitor = 1;
                }
                else
                {
                    번모니터ToolStripMenuItem1.Enabled = true;
                }
                Bitmap bitmap = new Bitmap((Bitmap)Image.FromFile("1px.png"));
                if (monitor == 1)
                {
                    bitmap = Base64ToBitmap(jObject["First"].ToString());
                }
                else
                {
                    bitmap = Base64ToBitmap(jObject["Second"].ToString());
                }
                pictureBox1.Image = bitmap;
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
            Bitmap bitmap = new Bitmap((Bitmap)Image.FromStream(ms));
            return bitmap;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            looping = false;
        }

        private void 금지ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 번모니터ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monitor = 1;
        }

        private void 번모니터ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            monitor = 2; 
        }
    }
}
