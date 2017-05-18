using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    public class HttpPostImage
    {
        public void PostImage()
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            byte[] imagebytearraystring = ImageFileToByteArray(@"C:\Users\Downloads\icon.png");
            form.Add(new ByteArrayContent(imagebytearraystring, 0, imagebytearraystring.Count()), "profile_pic", "hello1.jpg");
            HttpResponseMessage response = httpClient.PostAsync("http://www.appsgeyser.com/cropper.php?9232157", form).Result;

            httpClient.Dispose();
            string sd = response.Content.ReadAsStringAsync().Result;
        }

        private byte[] ImageFileToByteArray(string fullFilePath)
        {
            FileStream fs = File.OpenRead(fullFilePath);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;
        }
    }
}
