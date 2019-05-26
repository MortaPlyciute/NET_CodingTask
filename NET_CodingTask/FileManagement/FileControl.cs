using NET_CodingTask.DBLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NET_CodingTask.FileManagement
{
	public class FileControl : IFileControl
	{
		public TaxModel ReadFromFile()
		{
			TaxModel tax = new TaxModel();

			try
			{
				List<string> readText = new List<string>();
				string line;
				StreamReader file = new StreamReader(@"c:\Tax.txt");
				while ((line = file.ReadLine()) != null)
				{
					readText.Add(line);
				}

				file.Close();

				tax.MunicipalityName = readText[0];
				tax.TaxValue = Decimal.Parse(readText[1]); //format!!!
				tax.StartDate = DateTime.Parse(readText[2]);
				if (readText[3] != "-")
					tax.EndDate = DateTime.Parse(readText[3]);
				tax.TaxType = int.Parse(readText[4]);

			}
			catch (Exception)
			{
				return null;
			}

			return tax;
		}
	}
}
