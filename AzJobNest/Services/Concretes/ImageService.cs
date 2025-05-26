using AzJobNest.Services.Abstract;

namespace AzJobNest.Services.Concretes;

public class ImageService : IImageService
{
    public string CreateImage(IFormFile file, string webRootPath, string folderName)
    {
        if (!IsValidImage(file)) return String.Empty;

        string fileExtension = Path.GetExtension(file.FileName);
        string fileName = Guid.NewGuid().ToString() + fileExtension;

        string path = Path.Combine(webRootPath, folderName);

        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }

    public void DeleteImage(string path)
    {
        if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
    }


    public string UpdateImage(IFormFile file, string webRootPath, string folderName, string oldUrl)
    {
        if (!IsValidImage(file)) return String.Empty;
        DeleteImage(Path.Combine(webRootPath, folderName, oldUrl));
        return CreateImage(file, webRootPath, folderName);
    }

    public bool IsValidImage(IFormFile file)
    {
        if (file == null) return false;
        if (file.FileName == null) return false;
        if (!file.ContentType.StartsWith("image/")) return false;
        if (!file.ContentType.Contains("image")) return false;
        if (file.Length > 2_000_000 || file.Length == 0) return false;

        return true;
    }
}
