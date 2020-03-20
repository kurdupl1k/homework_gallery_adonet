using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Project.Data.Helpers
{
  public static class CompressImage
  {
    public static Bitmap CreateImage(Bitmap originalPic, int maxWidth, int maxHeight)
    {
      try
      {
        int width = originalPic.Width, height = originalPic.Height;
        int widthDiff = (width - maxWidth), heightDiff = (height - maxHeight);
        bool doWidthResize = (maxWidth > 0 && width > maxWidth && widthDiff > -1 &&
          widthDiff > heightDiff);
        bool doHeightResize = (maxHeight > 0 && height > maxHeight && heightDiff > -1 &&
          heightDiff > widthDiff);

        if (doWidthResize || doHeightResize || (width.Equals(height) &&
          widthDiff.Equals(heightDiff)))
        {
          int start;
          decimal divider;

          if (doWidthResize)
          {
            start = width;
            divider = Math.Abs((decimal)start / maxWidth);
            width = maxWidth;
            height = (int)Math.Round((height / divider));
          }
          else
          {
            start = height;
            divider = Math.Abs((decimal)start / maxHeight);
            height = maxHeight;
            width = (int)Math.Round((width / divider));
          }
        }
        using (Bitmap outBitmap = new Bitmap(width, height, PixelFormat.Format16bppRgb555))
        {
          using (Graphics outGraphics = Graphics.FromImage(outBitmap))
          {
            outGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            outGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode
              .HighQualityBicubic;
            outGraphics.DrawImage(originalPic, 0, 0, width, height);

            return new Bitmap(outBitmap);
          }
        }
      }
      catch { return null; }
    }
  }
}