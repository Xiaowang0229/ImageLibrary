using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace ImageLibrary
{
    public class Xiaowang0229
    {
        public class Image
        {
            public static ImageSource ConvertByteArrayToImageSource(byte[] imageBytes)
            {
                if (imageBytes == null || imageBytes.Length == 0) return null;

                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    return bitmapImage;
                }
            }
            public static bool ConvertToPngAndSave(byte[] imageBytes, string savePath)
            {
                

                if (imageBytes == null || imageBytes.Length == 0)
                    throw new ArgumentException("byte[] 不能为空");

                try
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(ms))
                    {
                        image.Save(savePath, ImageFormat.Png);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("转换失败: " + ex.Message);
                    return false;
                }
            }
            public static BitmapImage LoadImageFromPath(string imagePath)
            {
                if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
                {
                    return null;
                }

                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                    bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                    bitmap.EndInit();
                    bitmap.Freeze();

                    return bitmap;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"加载图片失败: {imagePath}，错误: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
