using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FaceAlgorismTestConsole
{
    public class FaceEmbeddingCache
    {
        private readonly IMemoryCache _cache;
        private readonly FaceAlgorism faceAlgorism;

        public FaceEmbeddingCache(IMemoryCache cache, FaceAlgorism faceAlgorism)
        {
            _cache = cache;
            this.faceAlgorism = faceAlgorism;
        }

        public void EmbeddingCache(IntPtr pRecognizer)
        {
            List<FaceCache> faceCaches = new List<FaceCache>();
            
            string[] jpgFiles = Directory.GetFiles("E:\\CUBOX\\Private\\CSharp\\FaceAlgorismTestConsole\\bin\\Debug\\netcoreapp3.1\\cubox");
            foreach (var item in jpgFiles.Select((value, i)=> (value, i)))
            {
                byte[] imageBytes = File.ReadAllBytes(item.value);

                byte[] srcEmbed = faceAlgorism.FaceExtract(pRecognizer, imageBytes,false);
                
                faceCaches.Add(new FaceCache { No =item.i, Value = srcEmbed, Url = item.value });
            }
            _cache.Set("Face", faceCaches);
        }
    }
}
