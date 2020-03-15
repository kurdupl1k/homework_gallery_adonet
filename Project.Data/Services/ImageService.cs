using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using Project.Data.Models;
using Project.Data.ViewModels;
using Project.Data.Helpers;

namespace Project.Data.Services
{
  public class ImageService
  {
    public bool Exists(Func<Models.Image, bool> func)
    {
      using (EFContext context = new EFContext())
        return context.Images.Any(func);
    }

    public void Add(ImageDTO elem)
    {
      using (EFContext context = new EFContext())
      {
        string image_name = Guid.NewGuid().ToString() + ".jpg";
        System.Drawing.Image img = System.Drawing.Image.FromFile(elem.Path);
        img = CompressImage.CreateImage((Bitmap)img, 500, 500);
        img.Save(Environment.CurrentDirectory + "//" + image_name, ImageFormat.Jpeg);

        Models.Image image = new Models.Image()
        {
          Source = image_name,
          UserId = elem.UserId
        };

        context.Images.Add(image);
        context.SaveChanges();
      }
    }
  }
}