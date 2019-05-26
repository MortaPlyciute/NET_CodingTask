using System;
using System.Diagnostics;
using NET_CodingTask;

namespace UserInterfaceApp
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = "";
			while (input != "x")
			{
				Console.WriteLine("To get tax rate: [Municipality] [Date YYYY-MM-DD]");
				Console.WriteLine("To update DB: update");
				Console.WriteLine("To exit: x");
				Console.WriteLine();

				input = Console.ReadLine();

				Process p = new Process();
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;

				if (input == "update")
				{
					p.StartInfo.FileName = "NET_CodingTask.exe" + " " + input;
					p.Start();
					string output = p.StandardOutput.ReadToEnd();
					p.WaitForExit();
				}
				else if (input == "")
				{
					p.StartInfo.FileName = "NET_CodingTask.exe" + " " + input;
					p.Start();
					string output = p.StandardOutput.ReadToEnd();
					p.WaitForExit();
				}
				else if (input != "x")
				{
					Console.WriteLine("BAD INPUT!");
				}
			}
		}
	}
}
