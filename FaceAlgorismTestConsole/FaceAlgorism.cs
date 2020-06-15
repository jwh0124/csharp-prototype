using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
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

        //얼굴 추출
        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ResultCode FaceExtraction(IntPtr pRecognizer, byte[] jpgData, long imageLen, CSResultVal retValue, byte[] embedding, int size);

        //얼굴 매치(비교)
        [DllImport("CUFaceRecognizer.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float MatchFeature(IntPtr pRecognizer, byte[] srcFeature, long srcFeatureLen, byte[] destFeature, long destFeatureLen);

        public byte[] FaceExtract(IntPtr pRecognizer, byte[] imageBytes)
        {
            CSResultVal retVal = new CSResultVal();
            byte[] embedding = new byte[2048];

            ResultCode extraction = FaceExtraction(pRecognizer, imageBytes, imageBytes.Length, retVal, embedding, 2048);
            /*if (extraction.Equals(ResultCode.SUCCESS))
            {
                List<FaceCache> faceCaches = new List<FaceCache>();
                faceCaches.Add(new FaceCache { No = 1, Value = embedding });
                _cache.Set("Face", faceCaches);
                if(!_cache.TryGetValue("Face", out faceCaches))
                {
                    faceCaches.Add(new FaceCache { No = 2, Value = embedding });
                }
                
                // 메모리에 등록
                _cache.Set("Face", faceCaches);                
            }*/
            
            return embedding;
        }

        public float FaceMatch(IntPtr pRecognizer, byte[] srcEmbed, byte[] desEmbed)
        {
            return MatchFeature(pRecognizer, srcEmbed, srcEmbed.Length, desEmbed, desEmbed.Length);
        }
    }
}
