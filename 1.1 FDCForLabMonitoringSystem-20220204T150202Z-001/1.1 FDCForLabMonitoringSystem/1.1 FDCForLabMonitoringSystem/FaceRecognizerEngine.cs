using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Emgu.Util;
using System.Data;
using System.Data.SqlClient;

using Emgu.CV.Util;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace _1._1_FDCForLabMonitoringSystem
{
    public class FaceRecognizerEngine
    {
       //private FaceRecognizer _faceRecognizer ;
        private DataAccess.FaceDataStore _faceDataStore;
        private String _recognizerFilePath;

        
        public FaceRecognizerEngine(String databasePath, String recognizerFilePath)
        {
            _recognizerFilePath = recognizerFilePath;
            _faceDataStore = new DataAccess.FaceDataStore();
           // _faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);            
        }

        public bool TrainRecognizer()
        {
            var allFaces = _faceDataStore.CallFaces("ALL_USERS");
            if (allFaces != null)
            {
                var faceImages = new Image<Gray, byte>[allFaces.Count];
                var faceLabels = new int[allFaces.Count];
                for (int i = 0; i < allFaces.Count; i++)
                {
                    Stream stream = new MemoryStream();
                    stream.Write(allFaces[i].ImageData, 0, allFaces[i].ImageData.Length);
                    var faceImage = new Image<Gray, byte>(new Bitmap(stream));
                    //faceImages[i] = faceImage.Resize(100, 100, Inter.Cubic);
                    faceLabels[i] = allFaces[i].GeneralImageId;
                }
                //_faceRecognizer.Train(faceImages, faceLabels);
                //_faceRecognizer.Write(_recognizerFilePath);
            }
            return true;

        }

        public void LoadRecognizerData()
        {
            //_faceRecognizer.Read(_recognizerFilePath);
        }

        public int RecognizeUser(Image<Gray, byte> userImage)
        {
            /*  Stream stream = new MemoryStream();
              stream.Write(userImage, 0, userImage.Length);
              var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            //_faceRecognizer.Read(_recognizerFilePath);

            //var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic));
            return 0; // result.Label;
        }
    }
}
