using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorAzureTesting
{
	using Microsoft.WindowsAzure;
	using Microsoft.WindowsAzure.Storage;

	public class BlobService
	{
		public void CreateBlob(string path, string reference)
		{
			var storage = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

			var blobClient = storage.CreateCloudBlobClient();

			var container = blobClient.GetContainerReference("mycontainer");
			
			container.CreateIfNotExists();

			var blockBlob = container.GetBlockBlobReference(reference);

			using (var fileStream = System.IO.File.OpenRead(path))
			{
				blockBlob.UploadFromStream(fileStream);
			}
		}
	}
}
