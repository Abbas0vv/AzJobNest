using AzJobNest.Services.Abstract;
public class FileService : IFileService
{
    public string CreateFile(IFormFile file, string webRootPath, string folderName)
    {
        if (!IsValidFile(file)) return string.Empty;

        string extension = Path.GetExtension(file.FileName);
        string fileName = Guid.NewGuid() + extension;
        string path = Path.Combine(webRootPath, folderName);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }

    public void DeleteFile(string path)
    {
        if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);
    }

    public string UpdateFile(IFormFile file, string webRootPath, string folderName, string oldUrl)
    {
        if (!IsValidFile(file)) return string.Empty;

        DeleteFile(Path.Combine(webRootPath, folderName, oldUrl));
        return CreateFile(file, webRootPath, folderName);
    }

    public bool IsValidFile(IFormFile file)
    {
        var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
        string extension = Path.GetExtension(file.FileName).ToLower();

        if (file == null || file.FileName == null) return false;
        if (file.Length == 0 || file.Length > 5_000_000) return false;
        if (!allowedExtensions.Contains(extension)) return false;

        return true;
    }
}
