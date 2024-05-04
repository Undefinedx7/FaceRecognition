﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace FaceRecognition
{
    public partial class FacialRecognitionForm : Form
    {

        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        Image<Bgr, Byte> faceResult = null;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, Byte>>();
        List<int> PersonsLabes = new List<int>();
        bool enableSaveImage = false;
        bool isTrained = false;
        EigenFaceRecognizer recognizer;
        List<string> PersonsNames = new List<string>();

        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        private bool faceDetectionEnabled = false;

        #region 
        public FacialRecognitionForm()
        {
            InitializeComponent();
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            

            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            Application.Idle += ProcessFrame;

            
        }


        private void ProcessFrame(object sender, EventArgs e)
        {
            
            // 1: Video Capture

            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(capturePictureBox.Width, capturePictureBox.Height, Inter.Cubic);

                // 2: Face Detection
                if (faceDetectionEnabled)
                {

                    // Convertir l'image couleur en gris

                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);

                    //amelioration de l'image

                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);

                    //si visage detecter
                    #endregion

                    #region 
                    if (faces.Length > 0)
                    {

                        foreach (var face in faces)
                        {
                            //carré sur visage 

                             CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            // 3: Ajouter une personne

                            //Assign le visage a la pictureBox facePictureBox
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            facePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            facePictureBox.Image = resultImage.Bitmap;

                            if (enableSaveImage)
                            {
                                //crée le repertoire si n'existe pas
                                string path = Directory.GetCurrentDirectory() + @"\imagesErgs";
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);
                                //sauvgarder 5 images avec un délais de 1000 ms
                                //crée une tache pour evité de noyer le processeur
                                Task.Factory.StartNew(() => {
                                    for (int i = 0; i < 10; i++)
                                    {
                                        //redimensionner l'image
                                        resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + nameTextBox.Text + "_" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".jpg");
                                        Thread.Sleep(1000);
                                    }
                                });
                            }
                            enableSaveImage = false;
                            #endregion
                            if (addPersonButton.InvokeRequired)
                            {
                                addPersonButton.Invoke(new ThreadStart(delegate {
                                    addPersonButton.Enabled = true;
                                }));
                            }
                            #region 
                            // 5 reconnaitre le visage
                            if (isTrained)
                            {
                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                                var result = recognizer.Predict(grayFaceResult);
                                pictureBox1.Image = grayFaceResult.Bitmap;
                                pictureBox2.Image = TrainedFaces[result.Label].Bitmap;
                                Debug.WriteLine(result.Label + ". " + result.Distance);
                                // si visage dans le dossier
                                if (result.Label != -1 && result.Distance < 2000)
                                {
                                    CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                }
                                //si pas de visage connu
                                else
                                {
                                    CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                                }
                                #endregion
                            }
                        }
                    }
                }

                //afficher dans la pictureBox capturePictureBox
                capturePictureBox.Image = currentFrame.Bitmap;
            }

            //pour reduire la conso ram
            if (currentFrame != null)
                currentFrame.Dispose();
        }
        #region bouton
        private void detectButton_Click(object sender, EventArgs e)
        {
            faceDetectionEnabled = true;

        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
            addPersonButton.Enabled = false;
            enableSaveImage = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            addPersonButton.Enabled = true;
            enableSaveImage = false;
        }
        #endregion

        #region 
        private bool TrainImageFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 2000;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();

            try
            {
                string path = Directory.GetCurrentDirectory() + @"\imagesErgs";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> imagesErg = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(imagesErg, imagesErg);
                    TrainedFaces.Add(imagesErg);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);

                }

                if (TrainedFaces.Count() > 0)
                {
                    
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());

                    isTrained = true;
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }

        }

 

        private void trainButton_Click(object sender, EventArgs e)
        {
            TrainImageFromDir();
        }

    }
    #endregion
}

