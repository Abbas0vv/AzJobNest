namespace AzJobNest.Services.Abstract;

public interface IImageService
{
    string CreateImage(IFormFile file, string webRootPath, string folderName);
    string UpdateImage(IFormFile file, string webRootPath, string folderName, string oldUrl);
    void DeleteImage(string path);
    bool IsValidImage(IFormFile file);
}
