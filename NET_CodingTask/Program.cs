using NET_CodingTask.DBLayer;
using NET_CodingTask.FileManagement;
using System;

namespace NET_CodingTask
{
	class Program
	{

		static void Main(string[] args)
		{
			UserInterfaceMock();
		}

		static void ProcessMain(string[] args)
		{
			TaxManagementClass management = new TaxManagementClass(new FileControl(), new DBControl());
			switch (args.Length)
			{
				case 1:
					Console.WriteLine(management.UpdateFromFile(args[0]));
					break;
				case 2:
					Console.WriteLine(management.FindTax(args[0], args[1]));
					break;
				default:
					Console.WriteLine(management.errorMessage);
					break;
			}
		}

		static void UserInterfaceMock()
		{
			string input = "";
			while (true)
			{
				Console.WriteLine("To get tax rate: [Municipality] [Date YYYY-MM-DD]");
				Console.WriteLine("To update DB: update");
				Console.WriteLine();

				input = Console.ReadLine();

				if (input == "update")
				{
					string[] arguments = new string[1];
					arguments[0] = input;
					ProcessMain(arguments);
				}
				else if (input.Split(' ').Length > 0 && input.Split(' ').Length < 3)
				{
					string[] arguments = input.Split(' ');
					ProcessMain(arguments);
				}
			}
		}
	}
}
