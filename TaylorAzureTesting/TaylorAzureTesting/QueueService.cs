using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorAzureTesting
{
	using Microsoft.WindowsAzure;
	using Microsoft.WindowsAzure.Storage;
	using Microsoft.WindowsAzure.Storage.Queue;

	public class QueueService
	{
		public void InsertMessage(string messageText)
		{
			var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

			var queueClient = storageAccount.CreateCloudQueueClient();

			var queue = queueClient.GetQueueReference("myqueue");

			queue.CreateIfNotExists();

			var message = new CloudQueueMessage(messageText);

			queue.AddMessage(message);
		}

		public string GetMessage()
		{
			// Retrieve storage account from connection string 
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
											CloudConfigurationManager.GetSetting("StorageConnectionString"));

			// Create the queue client 
			CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

			// Retrieve a reference to a queue 
			CloudQueue queue = queueClient.GetQueueReference("myqueue");

			string message = string.Empty;
			try
			{
				// Get the next message will pop 
				CloudQueueMessage retrievedMessage = queue.GetMessage();
				message = retrievedMessage.AsString;

			}
			catch (Exception)
			{
				message = "queue Empty";
			}

			return message;
		}


	}
}
