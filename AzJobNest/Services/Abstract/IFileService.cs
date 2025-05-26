namespace AzJobNest.Services.Abstract;

public interface IFileService
{
    string CreateFile(IFormFile file, string webRootPath, string folderName);
    string UpdateFile(IFormFile file, string webRootPath, string folderName, string oldUrl);
    void DeleteFile(string path);
    bool IsValidFile(IFormFile file);
}

