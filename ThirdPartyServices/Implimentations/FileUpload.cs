using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobStorage.Interfaces;
using AzureBlobStorage.Models;
using Microsoft.AspNetCore.Http;

namespace AzureBlobStorage.Implimentations
{
    public class FileUpload : IFileUpload
    {
        private readonly BlobServiceClient  _blobServiceClient;
        public FileUpload(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        
        public BlobServiceClient BlobServiceClient { get; }

        public async Task<UrlsModel> ImageUpload(IFormFile file)
        {
            var ConteType = new String[] { "image/png", "image/jpg", "image/jpeg" };

            if(!ConteType.Contains(file.ContentType))
            {
                throw new InvalidDataException("Only Image files allowed");
            }
          
            try
            {
               
                var blobcontainer = _blobServiceClient.GetBlobContainerClient("bookstore");

                var blobclient = blobcontainer.GetBlobClient(file.FileName.Replace(' ', '-').ToLower());

                 await blobclient.UploadAsync(file.OpenReadStream(),
                    new BlobHttpHeaders {ContentType = file.ContentType});

                var imagepath = blobclient.Uri.ToString();

                return new UrlsModel(imagepath);
            }
            catch (Exception)
            {
                throw new Exception("Some went wrong while uploading image to Azure Blob Storage");
            }
            
        }
    }
}
