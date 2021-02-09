using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Microsoft.CognitiveSearch.Skills.Image
{
    public class ImageStore
    {
        private CloudBlobContainer libraryContainer;

        public ImageStore(string blobConnectionString, string containerName)
        {
            Console.WriteLine("Connection string: {0}", blobConnectionString);
            Console.WriteLine("Container Connection string: {0}", containerName);
            Console.WriteLine("library Connection string: {0}", libraryContainer);


            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(blobConnectionString);
            Console.WriteLine("Connection string: {0}", blobConnectionString);
            Console.WriteLine("Storage account: {0}", storageAccount.ToString());

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            libraryContainer = blobClient.GetContainerReference(containerName);
        }

        public async Task<string> UploadImageToLibrary(Stream stream, string name, bool overwrite = false)
        {
            CloudBlockBlob blockBlob = libraryContainer.GetBlockBlobReference(name);
            if (!await blockBlob.ExistsAsync())
            {
                await blockBlob.UploadFromStreamAsync(stream);

                blockBlob.Properties.ContentType = "image/jpg";
                await blockBlob.SetPropertiesAsync();
            }

            return blockBlob.Uri.ToString();
        }

        public Task<string> UploadToBlob(byte[] data, string name, bool overwrite = false)
        {
            return UploadImageToLibrary(new MemoryStream(data), name, overwrite);
        }

        public Task<string> UploadToBlob(string data, string name, bool overwrite = false)
        {
            return UploadImageToLibrary(new MemoryStream(Convert.FromBase64String(data)), name, overwrite);
        }
    }
}
