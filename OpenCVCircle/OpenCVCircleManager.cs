using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVCircle
{
    class OpenCVCircleManager
    {
     
        public static void ProcessCircleImage(string filePath)
        {

            //create an image object from the image path
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(filePath);

            //create a temp image from the source image
            Image<Bgr, Byte> gray = new Image<Bgr, Byte>(img.Size);

            //convert the image to gray colurs than we can work on it 
            CvInvoke.CvtColor(img, gray, ColorConversion.Bgr2Gray);

            //Remove "noise"
            CvInvoke.GaussianBlur(gray, gray, new Size(3, 3), 1);

            //find circles in the image by the follwing parameters
            // CircleF[] circles = CvInvoke.HoughCircles(gray, HoughType.Gradient, 2.0, 20.0, 180, 120, 5);
            // CircleF[] circles = CvInvoke.HoughCircles(gray, HoughType.Gradient, 2.0, img.Height/4.0, 180, 120, 5);
            CircleF[] circles = CvInvoke.HoughCircles(gray, HoughType.Gradient, 2.0, 50.0, 180, 60, 5);


            //for each circule we found - draw its in red color
            foreach (CircleF circle in circles)
                CvInvoke.Circle(img, Point.Round(circle.Center), (int)circle.Radius,new Bgr(Color.Red).MCvScalar,2);
            
            // save the changes 
            img.Save(filePath);
            
        }
    }
}
