using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Web;

namespace SCSA
{
    public partial class SCSASandMessage : Form
    {
        public string url;
        public SCSASandMessage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string uri = $"{url}/{HttpUtility.UrlEncode(textBox1.Text,System.Text.Encoding.UTF8)}";
            uri = uri.Replace("+", "%20");
            client.DownloadString(uri);
            Close();
        }
    }
}
