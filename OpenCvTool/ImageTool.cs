using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenCvTool
{
    public class ImageTool
    {
        /// <summary>
        /// 人脸识别训练结果特征文件
        /// </summary>
        private string faceFile;
        public ImageTool()
        {
            faceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"haarcascade_frontalface_default.xml");
        }

        /// <summary>
        /// 从图片里裁剪人脸
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        public List<string> CutFaceFromPic(string pic)
        {
            List<string> result = null;
            if (!File.Exists(pic))
            {
                throw new FileNotFoundException(pic);
            }
            using CascadeClassifier cascade = new CascadeClassifier(faceFile);
            using Mat src = new Mat(pic, ImreadModes.Color);
            using Mat gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Rect[] faces = cascade.DetectMultiScale(gray, 1.08, 2, HaarDetectionType.ScaleImage, new Size(200, 200));
            if (faces?.Length > 0)
            {
                result = new List<string>(faces.Length);
                foreach (Rect face in faces)
                {
                    string facePic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{DateTime.Now.ToString("yyyyMMddHHssmmfff")}-{Guid.NewGuid().ToString()}.jpg");
                    if (src[face].SaveImage(pic))
                    {
                        result.Add(pic);
                    }
                }
            }
            return result ?? new List<string>();
        }
    }
}