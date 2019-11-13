using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace SCSA
{
    public partial class SCSASandMessage : Form
    {
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
            JObject setting = JObject.Parse(client.DownloadString("https://api.myjson.com/bins/t8642"));
            setting["havemessage"] = true;
            setting["message"] = textBox1.Text;
            client.Headers.Add("Content-Type", "application/json");
            client.UploadString("https://api.myjson.com/bins/t8642","PUT",setting.ToString());
            Close();
        }
    }
}
