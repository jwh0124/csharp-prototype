using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FaceAlgorismTestConsole
{
    public class FaceAlgorism
    {
        readonly IMemoryCache _cache;

        public FaceAlgorism(IMemoryCache cache)
        {
            _cache = cache;
        }

        //얼굴 감지
        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern ResultCode FaceDetection(IntPtr pRecognizer, byte[] frame, int imageLen, IntPtr retValue);

        //얼굴 추출
        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern ResultCode FaceExtraction(IntPtr pRecognizer, byte[] jpgData, long imageLen, CSResultVal retValue, byte[] embedding, int size, bool isCropped);

        //얼굴 매치(비교)
        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float MatchFeature(IntPtr pRecognizer, byte[] srcFeature, long srcFeatureLen, byte[] destFeature, long destFeatureLen);

        public byte[] FaceDetectionTest(IntPtr pRecognizer, byte[] imageBytes)
        {
            CSResultVal resultVal = new CSResultVal();

            int resultSize = Marshal.SizeOf(typeof(CSResultVal));
            IntPtr resultPtr = Marshal.AllocHGlobal(resultSize);

            Marshal.StructureToPtr(resultVal, resultPtr, false);

            ResultCode detection = FaceDetection(pRecognizer, imageBytes, imageBytes.Length, resultPtr);

            CSResultVal result = new CSResultVal();
            result = (CSResultVal)Marshal.PtrToStructure(resultPtr, typeof(CSResultVal));
            var width = result.r - result.l;
            var height = result.b - result.t;

            if (result.confidence > 0.6 && result.l > 100)
            {
                // Result Confidence 비교
                // Result Rect 비교



                MemoryStream ms = new MemoryStream(imageBytes);
                Image sourceImage = Image.FromStream(ms);

                Rectangle rectangle = new Rectangle(result.l, result.t, width, height);

                using (Bitmap targetImage = new Bitmap(width, height,PixelFormat.Format24bppRgb))
                {
                    using (Graphics graphics = Graphics.FromImage(targetImage))
                    {
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        ImageCodecInfo myImageCodecInfo;
                        myImageCodecInfo = GetEncoderInfo("image/jpeg");
                        System.Drawing.Imaging.Encoder myEncoder;
                        EncoderParameter myEncoderParameter; 
                        EncoderParameters myEncoderParameters;

                        myEncoder = System.Drawing.Imaging.Encoder.Quality;

                        myEncoderParameters = new EncoderParameters(1);

                        myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                        myEncoderParameters.Param[0] = myEncoderParameter;


                        graphics.DrawImage(sourceImage, 0, 0, rectangle, GraphicsUnit.Pixel);
                        MemoryStream targetMS = new MemoryStream();
                        targetImage.Save(targetMS, myImageCodecInfo, myEncoderParameters);
                        targetImage.Save("E:\\CUBOX\\Private\\CSharp\\FaceAlgorismTestConsole\\bin\\Debug\\netcoreapp3.1\\test\\cropped.jpg", myImageCodecInfo, myEncoderParameters);
                        byte[] resultImage = targetMS.ToArray();
                        return resultImage;
                        /*graphics.DrawImage(sourceImage, 0, 0, rectangle, GraphicsUnit.Pixel);
                        targetImage.Save("E:\\CUBOX\\Private\\CSharp\\FaceAlgorismTestConsole\\bin\\Debug\\netcoreapp3.1\\test\\cropped.jpg", myImageCodecInfo, myEncoderParameters);
                        Image thumbnail = targetImage.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                        thumbnail.Save("E:\\CUBOX\\Private\\CSharp\\FaceAlgorismTestConsole\\bin\\Debug\\netcoreapp3.1\\test\\resize.jpg", myImageCodecInfo, myEncoderParameters);
                        MemoryStream ms1 = new MemoryStream(resultImage, 0, resultImage.Length);
                        thumbnail.Save(ms1, ImageFormat.Bmp);
                        resultImage = ms1.ToArray();*/
                    }
                }
            }


            Marshal.FreeHGlobal(resultPtr);

            return null;
        }


        public byte[] FaceExtract(IntPtr pRecognizer, byte[] imageBytes, bool isCropped)
        {
            CSResultVal retVal = new CSResultVal();
            byte[] embedding = new byte[2048];

            ResultCode extraction = FaceExtraction(pRecognizer, imageBytes, imageBytes.Length, retVal, embedding, 2048, isCropped);
            if (extraction.Equals(ResultCode.SUCCESS))
            {
                /*List<FaceCache> faceCaches = new List<FaceCache>();
                faceCaches.Add(new FaceCache { No = 1, Value = embedding });
                _cache.Set("Face", faceCaches);
                if (!_cache.TryGetValue("Face", out faceCaches))
                {
                    faceCaches.Add(new FaceCache { No = 2, Value = embedding });
                }

                // 메모리에 등록
                _cache.Set("Face", faceCaches);*/
            }

            //Console.WriteLine(embedding);
            
            return embedding;
        }

        public float FaceMatch(IntPtr pRecognizer, byte[] srcEmbed, byte[] desEmbed)
        {
            return MatchFeature(pRecognizer, srcEmbed, srcEmbed.Length, desEmbed, desEmbed.Length);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
