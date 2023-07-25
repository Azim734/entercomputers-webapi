namespace EnterComputers.Service.Common.Helpers;

public class MediaHelper
{
    public static string MakeImageName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid()+extension;
        return name;
    }


    public static string[] GetImageExtension()
    {
        return new string[]
        {
             // JPG files
             ".jpg",".jpeg",
             //Png files
             ".png",
             //Bmp files
             ".bmp",
             //Heic files
             ".heic"
        };
    }
}
