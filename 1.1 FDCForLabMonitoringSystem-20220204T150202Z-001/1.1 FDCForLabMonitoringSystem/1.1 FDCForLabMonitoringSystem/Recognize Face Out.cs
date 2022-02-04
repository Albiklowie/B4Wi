using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;


namespace _1._1_FDCForLabMonitoringSystem
{
    public partial class Recognize_Face_Out : Form
    {
        public SerialPort myport;

        public Recognize_Face_Out()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                // string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                // string[] Labels = Labelsinfo.Split('%');
                // NumLabels = Convert.ToInt16(Labels[0]);
                //ContTrain = NumLabels;
                //string LoadFaces;

                //for (int tf = 1; tf < NumLabels + 1; tf++)
                //{
                //    LoadFaces = "face" + tf + ".bmp";
                //    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                //    labels.Add(Labels[tf]);
                //}


                //here get the stored faces in the database
                DataAccess.FaceDataStore df = new DataAccess.FaceDataStore();
                List<Face> facesFromDb = new List<Face>();
                facesFromDb = df.CallFaces("ALL_USERS");
                ContTrain = facesFromDb.Count;
                foreach (Face f in facesFromDb)
                {
                    MemoryStream ms = new MemoryStream();
                    Byte[] img = f.ImageData;
                    Bitmap bmp = new Bitmap(new MemoryStream(img));
                    Image<Bgr, Byte> ColordImage = null;
                    ColordImage = new Image<Bgr, byte>(bmp);
                    Image<Gray, Byte> grayImage = ColordImage.Convert<Gray, Byte>();

                    trainingImages.Add(grayImage);
                    //labels.Add(f.ImageLabel.ToString());
                    labels.Add(f.GeneralImageId.ToString());
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

     

        public void Unlock()
        {
            //myport = new SerialPort();
            //myport.BaudRate = 9600;
            //myport.PortName = "COM8";
            //myport.Open();
            //myport.WriteLine("O");
            //myport.Close();

        }

        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        int _scheduleId;

        //LOAD LOAD LOAD LOAD
        private void Recognize_Face_Out_Load(object sender, EventArgs e)
        {
            timer1.Start();

            Date.Text = DateTime.Now.ToLongTimeString();
            Time.Text = DateTime.Now.ToLongDateString();

            //get available schedule based on current time
            DataTable dt = new DataTable();
            dt = DataAccess.GetAvailableSchedule();
            if (dt != null && dt.Rows.Count > 0)
            {
                _scheduleId = Convert.ToInt32(dt.Rows[0][0].ToString());
            }


            grabber = new Capture(2);
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);

        }

        string name, names = null;

        void FrameGrabber(object sender, EventArgs e)
        {
            //label3.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                    //get user id


                    //implement logic
                    if (DataAccess.IsStudent(name))
                    {
                        DataTable dt = new DataTable();
                        dt = DataAccess.GetDataSqlText("Select * from StudentsTable where StudentId=" + name);
                        UserIdTextbox.Text = dt.Rows[0][0].ToString();
                        FirstNameTextbox.Text = dt.Rows[0][3].ToString();
                        LastNameTextbox.Text = dt.Rows[0][4].ToString();
                        PositionTextBox.Text = "Student";
                        //Check if enrolled in the scheduled subject
                        //then Check if instructor is IN
                        if (DataAccess.IsInstructorIn(Convert.ToInt32(name), _scheduleId))
                        {

                            //If IN the allow entry -- for lock/unlock mechanism (no implementation yet)

                            //Then Record attendance
                            DataAccess.WriteAttendanceIN(Convert.ToInt32(name), DateTime.Now.Date, DateTime.Now, DateTime.Now, _scheduleId);
                            Unlock();
                        }
                        else
                        {
                            //if not IN then do not allow entry, issue message
                            //MessageBox.Show("No Instructor is IN right now");
                            label4.Visible = true;
                            label4.Text = "No Instructor is IN right now";
                        }

                    }
                    else if (DataAccess.IsInstructor(name))
                    {
                        DataTable dt = new DataTable();
                        DataTable dtA = new DataTable();
                        dtA = DataAccess.GetDataSqlText("Select * from AttendanceTable where OwnerId=" + name);
                        dt = DataAccess.GetDataSqlText("Select * from InstructorsTable where InstructorId=" + name);
                        UserIdTextbox.Text = dt.Rows[0][0].ToString();
                        FirstNameTextbox.Text = dt.Rows[0][1].ToString();
                        LastNameTextbox.Text = dt.Rows[0][2].ToString();
                        PositionTextBox.Text = "Instructor";
                        TimeinTextbox.Text = dtA.Rows[0][2].ToString();
                        //Allow entry --not yet implemented

                        //Then Record attendance
                        DataAccess.WriteAttendanceIN(Convert.ToInt32(name), DateTime.Now, DateTime.Now, DateTime.Now, _scheduleId);
                        Unlock();

                        label4.Visible = false;
                    }

                    else if (DataAccess.IsLabStaff(name))
                    {
                        DataTable dt = new DataTable();
                        DataTable dtA = new DataTable();
                        dt = DataAccess.GetDataSqlText("Select * from LabStaffTable where StaffId=" + name);
                        dtA = DataAccess.GetDataSqlText("Select * from AttendanceTable where OwnerId=" + name);
                        UserIdTextbox.Text = dt.Rows[0][0].ToString();
                        FirstNameTextbox.Text = dt.Rows[0][1].ToString();
                        LastNameTextbox.Text = dt.Rows[0][2].ToString();

                        TimeinTextbox.Text = dtA.Rows[0][2].ToString();

                        DataAccess.WriteAttendanceIN(Convert.ToInt32(name), DateTime.Now, DateTime.Now, DateTime.Now, _scheduleId);

                        Unlock();

                        //just allow entry - not yet implemented
                    }
                    else
                    {
                        //show warning
                        //MessageBox.Show("Not allowed entry at this time");

                    }

                }

                //NamePersons[t - 1] = name;
                //NamePersons.Add("");


                //Set the number of faces detected on the scene
                //label3.Text = facesDetected[0].Length.ToString();

                /*
                //Set the region of interest on the faces

                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);
                    currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                }
                 */

            }
            //t = 0;

            ////Names concatenation of persons recognized
            //for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            //{
            //    names = names + NamePersons[nnn] + ", ";
            //}
            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            //label4.Text = names;
            //names = "";
            ////Clear the list(vector) of names
            //NamePersons.Clear();

        }


    }
}
