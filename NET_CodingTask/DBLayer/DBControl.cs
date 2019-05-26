using System;
using System.Collections.Generic;
using System.Text;

namespace NET_CodingTask.DBLayer
{
	public class DBControl : IDBControl
	{
		public enum TaxTypes  {Yearly, Monthly, Weekly, Daily};
		private List<TaxModel> mockDB = new List<TaxModel>();

		public DBControl()
		{
			mockDB.Add(new TaxModel { MunicipalityName = "Vilnius"
									, TaxValue = 0.2m
									, StartDate = new DateTime(2019, 01, 01)
									, EndDate = new DateTime(2019, 12, 31)
									, TaxType = (int)TaxTypes.Yearly });

			mockDB.Add(new TaxModel { MunicipalityName = "Vilnius"
									, TaxValue = 0.4m
									, StartDate = new DateTime(2019, 05, 01)
									, EndDate = new DateTime(2019, 05, 31)
									, TaxType = (int)TaxTypes.Monthly });

			mockDB.Add(new TaxModel { MunicipalityName = "Vilnius"
									, TaxValue = 0.1m
									, StartDate = new DateTime(2019, 01, 01)
									, EndDate = null
									, TaxType = (int)TaxTypes.Daily });

			mockDB.Add(new TaxModel { MunicipalityName = "Vilnius"
									, TaxValue = 0.1m
									, StartDate = new DateTime(2019, 12, 25)
									, EndDate = null
									, TaxType = (int)TaxTypes.Daily });

		}

		public List<TaxModel> FindTaxes(string municipalityName)
		{
			List<TaxModel> taxes = new List<TaxModel>();

			taxes = mockDB.FindAll(p => p.MunicipalityName == municipalityName);

			return taxes;
		}

		public bool AddTax(TaxModel tax)
		{
			try
			{
				mockDB.Add(tax);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}
	}
}
