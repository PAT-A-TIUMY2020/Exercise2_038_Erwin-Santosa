using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using ServiceExercise_038_Erwin_Santosa;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerCode_038_Erwin_Santosa
{
    public partial class Form1 : Form
    {
        ServiceHost hostObject;
        Uri address = new Uri("http://localhost:8733/Mahasiswa");
        WebHttpBinding binding = new WebHttpBinding();

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hostObject = null;

            try
            {
                Task.Factory.StartNew(() =>
                {
                    hostObject = new ServiceHost(typeof(TI_UMY));
                    hostObject.Open();
                });
                label2.Text = "Server ON";
                label3.Text = "Klik OFF untuk menonaktifkan server";
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                hostObject = null;
                label2.Text = "Server Error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                hostObject.Abort();
                label2.Text = "Server OFF";
                label3.Text = "Klik ON untuk menghidupkan server";
                button2.Enabled = false;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                label2.Text = "Server Error";
            }
        }
    }
}
