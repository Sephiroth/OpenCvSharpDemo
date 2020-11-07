using OpenCvSharp;

namespace OpenCvTool
{
    public class VideoTool
    {
        /// <summary>
        /// 从rtsp协议链接读取保存视频
        /// </summary>
        /// <param name="rtspUrl"></param>
        /// <param name="saveFile"></param>
        /// <param name="isStop"></param>
        /// <returns></returns>
        public int SaveVideoFromRtsp(string rtspUrl, string saveFile, ref bool isStop)
        {
            //HandleRs rs = new HandleRs();
            using VideoCapture videoCapture = new VideoCapture(rtspUrl);
            FourCC fourCC = FourCC.FromFourChars('m', 'p', '4', 'v');
            if (!videoCapture.IsOpened())
            {
                return -1;//rs.SetError(-1, "saveFile打开失败");
            }
            double fps = videoCapture.Get(VideoCaptureProperties.Fps);
            double width = videoCapture.Get(VideoCaptureProperties.FrameWidth);
            double height = videoCapture.Get(VideoCaptureProperties.FrameHeight);
            Size size = new Size(width, height);
            using VideoWriter videoWriter = new VideoWriter(saveFile, fourCC, fps, size, true);

            using Mat frame = new Mat();
            while (isStop == false)
            {
                bool readRs = videoCapture.Read(frame);
                if (readRs)
                {
                    videoWriter.Write(frame);
                }
            }
            return 0;
        }


        public int RecordScreenVideo(string saveFile, ref bool isStop)
        {

            return 0;
        }
    }
}