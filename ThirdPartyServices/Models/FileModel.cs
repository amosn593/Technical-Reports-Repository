using Microsoft.AspNetCore.Http;

namespace AzureBlobStorage.Models
{
    public class FileModel
    {
        public IFormFile ImageFile { get; set; }
    }
}
