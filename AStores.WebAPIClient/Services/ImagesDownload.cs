using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Drawing;

namespace AStores.WebAPIClient.Services
{
    public class ImagesDownload
    {
        static HttpClient _client;
        static string _path;

        public ImagesDownload(HttpClient client, string path)
        {
            _client = client;
            _path = path;
        }

        static async Task GetProductAsync(string webapiPath, string imageName)
        {
            HttpResponseMessage response = await _client.GetAsync(webapiPath);
            if (response.IsSuccessStatusCode)
            {
                byte[] x = await response.Content.ReadAsByteArrayAsync();
                byteArrayToImage(x, imageName);
            }
        }

        static void byteArrayToImage(byte[] byteArrayIn, string imageName)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            returnImage.Save(_path + imageName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            returnImage.Dispose();
        }
    }
}
