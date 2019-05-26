using System;
using System.Collections.Generic;
using System.Text;

namespace NET_CodingTask.DBLayer
{
	public interface IDBControl
	{
		List<TaxModel> FindTaxes(string municipalityName);
		bool AddTax(TaxModel tax);
	}
}
