using System;
using System.Collections.Generic;
using System.Text;

namespace NET_CodingTask.DBLayer
{
	public class TaxModel
	{
		public string MunicipalityName { get; set; }

		public decimal TaxValue { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public int TaxType { get; set; }

	}
}
