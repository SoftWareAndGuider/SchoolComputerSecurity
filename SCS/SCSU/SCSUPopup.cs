using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace SCSU
{
    public partial class SCSUPopup : Form
    {
        public SCSUPopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string url = "http://localhost:1234/api/macJson";
            string mac = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
            //textBox1.Text = 학년, textBox2.Text = 반
            client.DownloadString($"{url}/{textBox1.Text}/{textBox2.Text}/{mac}");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int text = int.Parse(textBox1.Text);
            text++;
            textBox1.Text = text.ToString();
            if (textBox1.Text == "4")
            {
                textBox1.Text = "1";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int text = int.Parse(textBox1.Text);
            text--;
            textBox1.Text = text.ToString();
            if (textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int text = int.Parse(textBox2.Text);
            text++;
            textBox2.Text = text.ToString();
            if (textBox2.Text == "13")
            {
                textBox2.Text = "01";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int text = int.Parse(textBox2.Text);
            text--;
            textBox2.Text = text.ToString();
            if (textBox2.Text == "0")
            {
                textBox2.Text = "12";
            }
        }
    }
}
