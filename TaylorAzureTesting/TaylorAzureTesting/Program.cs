using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorAzureTesting
{
	class Program
	{
		static void Main(string[] args)
		{

			var queueService = new QueueService();

			//queueService.InsertMessage("");
			
			var message = queueService.GetMessage();

			Console.WriteLine(message);

			Console.ReadKey();

			//	Console.WriteLine("Enter Command: ");
			//	var cmd = Console.ReadLine();

			//	while (cmd != null && !cmd.Equals("end"))
			//	{
			//		if (!cmd.Equals("create blob"))
			//		{
			//			continue;
			//		}

			//		Console.WriteLine("Enter path:");
			//		var path = Console.ReadLine();

			//		Console.WriteLine("Name:");
			//		var name = Console.ReadLine();

			//		var blobService = new BlobService();
			//		blobService.CreateBlob(path, name);

			//		if (cmd.Equals("insert message"))
			//		{
			//			Console.WriteLine("Message:");
			//			string message = Console.ReadLine();
			//			QueueService queueService = new QueueService();
			//			queueService.InsertMessage(message);

			//		}

			//		if (cmd.Equals("get message"))
			//		{
			//			var queueService = new QueueService();
			//			var message = queueService.GetMessage();
			//			Console.WriteLine("Message Received: " + message);
			//		}

			//		Console.WriteLine("Enter Command: ");
			//		cmd = Console.ReadLine();
			//}


		}
	}
}
