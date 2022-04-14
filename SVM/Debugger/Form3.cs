using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Debugger
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
           
        }


        public void displayImage(String url)
        {
            WebRequest webRequest = WebRequest.Create(url);

            using (var response = webRequest.GetRequestStream())
            {
                pictureBox1.Image = Bitmap.FromStream(response);
            }
        }
    }
}
