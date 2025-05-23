using AzJobNest.Services.Abstract;

namespace AzJobNest.Services.Concretes;

public class FileService : IFileService
{
    public string CreateFile(IFormFile file, string webRootPath, string folderName)
    {
        if(!IsValidFile(file)) return String.Empty;

        string fileName = Guid.NewGuid().ToString() + file.FileName;
        string path = Path.Combine(webRootPath, folderName);

        using (var stream = new FileStream(Path.Combine(path,fileName), FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }

    public void DeleteFile(string path)
    {
        System.IO.File.Delete(path);
    }

    public string UpdateFile(IFormFile file, string webRootPath, string folderName, string oldUrl)
    {
        if(!IsValidFile(file)) return String.Empty;
        DeleteFile(Path.Combine(webRootPath,folderName,oldUrl));
        return CreateFile(file, webRootPath, folderName);    
    }

    public bool IsValidFile(IFormFile file)
    {
        if(file == null) return false;
        if(file.FileName == null) return false;
        if(!file.ContentType.Contains("image")) return false;
        if(file.Length > 2000000 && file.Length == 0) return false;

        return true;    
    }
}
