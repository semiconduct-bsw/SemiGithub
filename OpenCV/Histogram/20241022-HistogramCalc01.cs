using OpenCvSharp;

namespace _20241022_HistogramCalc01
{
    internal class Program
    {
        static void CalcHistogram(Mat image, out Mat hist, int bins, int rangeMax = 256)
        {
            hist = new Mat(bins, 1, MatType.CV_32F, new Scalar(0));
            float gap = rangeMax / (float)bins;

            for (int i = 0; i < image.Rows; i++)
            {
                for (int j = 0; j < image.Cols; j++)
                {
                    int idx = (int)(image.At<byte>(i, j) / gap);
                    hist.Set<float>(idx, hist.At<float>(idx) + 1);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("c:\\Temp\\opencv\\pixel_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("이미지를 로드할 수 없습니다.");
                return;
            }

            Mat hist;
            CalcHistogram(image, out hist, 256);   // 히스토그램 계산

            //Console.Write(hist.Dump());
            for (int i = 0; i < hist.Rows; i++)
            {
                Console.Write(hist.At<float>(i) + ", ");
            }
            Console.WriteLine();

            Cv2.ImShow("image", image);
            Cv2.WaitKey(); Cv2.DestroyAllWindows();
        }
    }
}
