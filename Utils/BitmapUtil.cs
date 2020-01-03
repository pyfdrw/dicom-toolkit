﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace SimpleDICOMToolkit.Utils
{
    public static class BitmapUtil
    {
        /// <summary>
        /// WriteableBitmap to BitmapImage
        /// </summary>
        /// <param name="wbm">WriteableBitmap</param>
        /// <returns>BitmapImage</returns>
        public static BitmapImage AsBitmapImage(this WriteableBitmap wbm)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wbm));
                encoder.Save(stream);
                BitmapImage bmImage = new BitmapImage();
                bmImage.BeginInit();
                bmImage.CacheOption = BitmapCacheOption.OnLoad;
                bmImage.StreamSource = stream;
                bmImage.EndInit();
                bmImage.Freeze();

                return bmImage;
            }
        }

        /// <summary>
        /// Bitmap to BitmapImage
        /// </summary>
        /// <param name="bitmapOriginal">Bitmap</param>
        /// <returns>BitmapImage</returns>
        public static BitmapImage AsBitmapImage(this Bitmap bitmapOriginal)
        {
            using (Bitmap bitmap = new Bitmap(bitmapOriginal))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    BitmapImage bmImage = new BitmapImage();
                    bmImage.BeginInit();
                    bmImage.CacheOption = BitmapCacheOption.OnLoad;
                    bmImage.StreamSource = stream;
                    bmImage.EndInit();
                    bmImage.Freeze();

                    return bmImage;
                }
            }
            
        }

        /// <summary>
        /// WriteableBitmap to Bitmap
        /// </summary>
        /// <param name="wbm">WriteableBitmap</param>
        /// <returns>Bitmap</returns>
        public static Bitmap AsBitmap(this WriteableBitmap wbm)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wbm));
                encoder.Save(stream);

                return new Bitmap(stream);
            }
        }

        /// <summary>
        /// BitmapImage to Bitmap
        /// </summary>
        /// <param name="bitmapImage">BitmapImage</param>
        /// <returns>Bitmap</returns>
        public static Bitmap AsBitmap(this BitmapImage bitmapImage)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(stream);

                return new Bitmap(stream);
            }
        }
    }
}
