using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalElectronicRecordSystem
{
    public partial class Form_Capture_Photo : ImageViewer
    {
        Capture capture;
        public Form_Capture_Photo()
        {
            InitializeComponent();
            
        }

        private void Form_Capture_Photo_Load(object sender, EventArgs e)
        {
            //viewer = new ImageBox(); //create an image viewer
            Capture capture = new Capture(); //create a camera captue
            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)
                viewer.Image = capture.QueryFrame(); //draw the image obtained from camera
            });
            viewer.ShowDialog(); //show the image viewer
        }
        private void StreamVideo(object sender, System.EventArgs e)
        {
            capture = new Capture();
            var img = capture.QueryFrame().ToImage<Bgr, byte>();
            var bmp = img.Bitmap;
            pictureBox1.Image = bmp;

            //Capture capture = new Capture();
            //var img = capture.QueryFrame().ToImage<Bgr, byte>();
            //var bmp = img.Bitmap;
            //pictureBox1.Image = bmp;
        }

        private void Form_Capture_Photo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Idle -= StreamVideo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Idle += StreamVideo;
        }
    }
}
