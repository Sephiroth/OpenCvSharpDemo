using OpenCvSharp;
using OpenCvTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenCvSharpDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private volatile bool isStop;
        private VideoTool videoTool;

        public MainWindow()
        {
            InitializeComponent();
            videoTool = new VideoTool();
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            string rtspUrl = "rtsp://admin:qq123456@10.1.72.238:554/h264/ch1/main/av_stream";
            string videoName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"{DateTime.Now.ToString("yyyyMMddHHmmss")}.mp4");
            Task.Factory.StartNew(() =>
            {
                var result = videoTool.SaveVideoFromRtsp(rtspUrl, videoName, ref isStop);
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(result == 0 ? "成功" : "失败");
                });
            });
        }

        private void stopBtnClick(object sender, RoutedEventArgs e)
        {
            isStop = true;
        }
    }
}