using NET_CodingTask.DBLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_CodingTask.FileManagement
{
	public interface IFileControl
	{
		TaxModel ReadFromFile();
	}
}
