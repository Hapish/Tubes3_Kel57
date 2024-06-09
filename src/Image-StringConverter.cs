using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace tubes3stima
{
    public class ImageConverter
    {
        // Function to convert image to binary
        public static byte[] ConvertImageToBinary(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        // Function to convert byte array to ASCII string
        public static string ConvertToAsciiString(byte[] imageBytes)
        {
            string base64String = Convert.ToBase64String(imageBytes);
            byte[] asciiBytes = Encoding.ASCII.GetBytes(base64String);
            return Encoding.ASCII.GetString(asciiBytes);
        }

        public static string ConvertImageToAsciiString(Image image)
        {
            byte[] imageBytes = ConvertImageToBinary(image);
            return ConvertToAsciiString(imageBytes);
        }
    }
}