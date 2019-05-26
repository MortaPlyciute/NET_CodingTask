using NET_CodingTask.DBLayer;
using NET_CodingTask.FileManagement;
using System;
using System.Collections.Generic;
using System.Text;
using static NET_CodingTask.DBLayer.DBControl;

namespace NET_CodingTask
{
	public class TaxManagementClass
	{
		public string errorMessage = "ERROR: bad arguments!";
		private IDBControl dbControl;
		private IFileControl fileControl;

		public TaxManagementClass(IFileControl _fileControl, IDBControl _dbControl)
		{
			dbControl = _dbControl;
			fileControl = _fileControl;
		}

		public string UpdateFromFile(string arg)
		{
			if (arg != "update")
				return errorMessage;

			TaxModel tax = fileControl.ReadFromFile();
			if (tax == null)
				return "ERROR: check file - something wrong!";

			bool updatePassed = dbControl.AddTax(tax);

			if (!updatePassed)
			{
				return "ERROR: inner DB error :( ";
			}

			string endDate = "-";
			if (tax.EndDate != null)
				endDate = DateTime.Parse(tax.EndDate.ToString()).ToString("yyyy-MM-dd");

			return "Taxes from file: " +
				"municipality " + tax.MunicipalityName +
				"; tax " + tax.TaxValue.ToString() +
				"; start date " + tax.StartDate.ToString("yyyy-MM-dd") +
				"; end date " + endDate +
				"; tax type " + Enum.GetName(typeof(TaxTypes), tax.TaxType);
		}

		public string FindTax(string municipalityName, string taxDate)
		{
			if (String.IsNullOrEmpty(municipalityName))
				return errorMessage;

			if (String.IsNullOrEmpty(taxDate))
				return errorMessage;

			DateTime givenDate = new DateTime();
			if (!DateTime.TryParse(taxDate, out givenDate))
				return errorMessage;

			List<TaxModel> taxes = dbControl.FindTaxes(municipalityName);

			if (taxes == null)
				return "No taxes found.";
			else if (taxes.Count == 0)
				return "No taxes found.";

			int? validTax = null;

			foreach(TaxModel tax in taxes)
			{
				if (tax.StartDate == givenDate && (int)TaxTypes.Daily == tax.TaxType)
					return "Tax: " + tax.TaxValue.ToString();

				if (tax.StartDate <= givenDate && tax.EndDate >= givenDate)
				{
					if (validTax == null)
						validTax = taxes.IndexOf(tax);
					else if (tax.TaxType > taxes[(int)validTax].TaxType)
						validTax = taxes.IndexOf(tax);
				}
			}

			return "Tax: " + taxes[(int)validTax].TaxValue.ToString();
		}
	}
}
