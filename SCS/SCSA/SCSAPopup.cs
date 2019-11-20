using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace SCSA
{
    public partial class SCSAPopup : Form
    {
        public SCSAPopup()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string[] url = new string[3]
            {
                $"http://2019swag.iptime.org:1234/api/imgJson/{textBox1.Text}/{textBox2.Text}",
                $"http://2019swag.iptime.org:1234/api/mgrJson/{textBox1.Text}/{textBox2.Text}",
                $"http://2019swag.iptime.org:1234/api/msgJson/{textBox1.Text}/{textBox2.Text}",
            };
            System.IO.File.WriteAllLines("url.txt",url);
            Close();
        }
    }
}
