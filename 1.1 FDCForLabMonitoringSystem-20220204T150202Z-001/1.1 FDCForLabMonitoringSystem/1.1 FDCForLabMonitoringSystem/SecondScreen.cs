using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Util;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;



namespace _1._1_FDCForLabMonitoringSystem
{
    public partial class SecondScreen : Form
    {

        Capture grabber = new Capture();
        Image<Bgr, Byte> currentFrame;

        public SecondScreen()
        {
            InitializeComponent();
        }

        private void SecondScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();

            Date.Text = DateTime.Now.ToLongTimeString();
            Time.Text = DateTime.Now.ToLongDateString();

            //open hit camera
            grabber = new Capture();
            grabber.QueryFrame();
            Application.Idle += new EventHandler(FrameGrabber);
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame().Resize(537, 420, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //imageBox1.Image = currentFrame;

            //MCvAvgComp[][] faceDetected = gray.DetectHaarCascade(face, 1.1, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            //result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Date.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
