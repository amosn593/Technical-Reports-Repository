namespace AzureBlobStorage.Models
{
    public class UrlsModel
    {
        public string Url { get; }

        public UrlsModel(string imagepath)
        {
            Url = imagepath;
        }
    }
}
