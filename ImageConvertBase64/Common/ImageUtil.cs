using System;
using System.IO;

namespace ImageSave.Common
{
    public class ImageUtil
    {
        public string ImageConvertToBase64(string Path)
        {
            return Convert.ToBase64String(File.ReadAllBytes(Path));
        }

        public void Base64ConvertToImage(string Base64, string writePath, string ImageName)
        {
            byte[] imageBytes = Convert.FromBase64String(Base64);

            try {
                File.WriteAllBytes(writePath + "\\" + ImageName, imageBytes);
            }
            catch (UnauthorizedAccessException)
            {

            }
        }
    }
}
