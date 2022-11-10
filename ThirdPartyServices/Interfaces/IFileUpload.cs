using AzureBlobStorage.Models;
using Microsoft.AspNetCore.Http;

namespace AzureBlobStorage.Interfaces
{
    public interface IFileUpload
    {
        Task<UrlsModel> ImageUpload(IFormFile image);
    }
}
