using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms;
using System.Net;
using System.IO;


namespace ConnectionChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = this.textBox1.Text;
            string user = this.textBox2.Text;
            string pass = this.textBox3.Text;
            try
            {
                var uri = new Uri(host);
                var cookies = new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.CookieContainer = cookies;
                request.ServicePoint.Expect100Continue = false;
                request.Method = "GET";
                request.Referer = "Referer: http://localhost/FlexiCapture12/Monitoring/winauth/Main/DBConnection";
                request.Accept = "image/webp,image/apng,image/*,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                request.Credentials = new NetworkCredential(user, pass);
                request.PreAuthenticate = true;
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                string htmlResponse = reader.ReadToEnd();
                MessageBox.Show(htmlResponse,"Success");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Error occured");
            }

        }
    }
}
