using System.Data.SqlTypes;

namespace HWASP.Services.Upload
{
    public interface IUploadService
    {
        String SaveFormFile(IFormFile formFile);
        String SaveFormFile(IFormFile formFile, String path);
        String SaveFormFile(IFormFile formFile, String path, IEnumerable<String> extensionsAllowed);
    }
}
