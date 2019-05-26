using NET_CodingTask.DBLayer;
using NET_CodingTask;
using NET_CodingTask.FileManagement;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
	public class TaxManagementClassTests
	{

		[Test]
		public void GivenFindTax_WhenBadDate_ThenThrow()
		{
			//Arrange
			var dbControlMock = Substitute.For<IDBControl>();
			var fileControlMock = Substitute.For<IFileControl>();
			var taxManager = new TaxManagementClass(fileControlMock, dbControlMock);
			string goodMunicipalityParameter = "Vilnius";
			string badDateParameter = "201-905-01";
			string expectedResult = "ERROR: bad arguments!";

			//Act
			string result = taxManager.FindTax(goodMunicipalityParameter, badDateParameter);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void GivenFindTax_WhenNullDate_ThenThrow()
		{
			//Arrange
			var dbControlMock = Substitute.For<IDBControl>();
			var fileControlMock = Substitute.For<IFileControl>();
			var taxManager = new TaxManagementClass(fileControlMock, dbControlMock);
			string goodMunicipalityParameter = "Vilnius";
			string badDateParameter = null;
			string expectedResult = "ERROR: bad arguments!";

			//Act
			string result = taxManager.FindTax(goodMunicipalityParameter, badDateParameter);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void GivenFindTax_WhenBadMunicipality_ThenThrow()
		{
			//Arrange
			var dbControlMock = Substitute.For<IDBControl>();
			var fileControlMock = Substitute.For<IFileControl>();
			var taxManager = new TaxManagementClass(fileControlMock, dbControlMock);
			string badMunicipalityParameter = "Test";
			string goodDateParameter = "2019-01-01";
			string expectedResult = "No taxes found.";

			//Act
			string result = taxManager.FindTax(badMunicipalityParameter, goodDateParameter);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void GivenFindTax_WhenNullMunicipality_ThenThrow()
		{
			//Arrange
			var dbControlMock = Substitute.For<IDBControl>();
			var fileControlMock = Substitute.For<IFileControl>();
			var taxManager = new TaxManagementClass(fileControlMock, dbControlMock);
			string badMunicipalityParameter = null;
			string goodDateParameter = "2019-01-01";
			string expectedResult = "ERROR: bad arguments!";

			//Act
			string result = taxManager.FindTax(badMunicipalityParameter, goodDateParameter);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void GivenFindTax_WhenGoodParameters_ThenReturnTax() //Fail - no DB, List empty
		{
			//Arrange
			var dbControlMock = Substitute.For<IDBControl>();
			var fileControlMock = Substitute.For<IFileControl>();
			var taxManager = new TaxManagementClass(fileControlMock, dbControlMock);
			string goodMunicipalityParameter = "Vilnius";
			string goodDateParameter = "2019-01-03";
			string expectedResult = "Tax: 0,2";

			//Act
			string result = taxManager.FindTax(goodMunicipalityParameter, goodDateParameter);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void GivenUpdateFromFile_WhenGoodFileGoodArg_ThenAddRecord()
		{
			//Arrange
			var dbControlMock = Substitute.For<IDBControl>();
			var fileControlMock = Substitute.For<IFileControl>();
			var taxManager = new TaxManagementClass(fileControlMock, dbControlMock);
			string arg = "update";
			string expectedResult = "Taxes from file: " +
				"municipality " + "Vilnius" +
				"; tax " + "0,3" +
				"; start date " + "2019-05-30" +
				"; end date " + "-" +
				"; tax type " + "Daily" ;

			//Act
			string result = taxManager.UpdateFromFile(arg);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void GivenUpdateFromFile_WhenBadFile_ThenThrow()
		{
			//Arrange
			var dbControlMock = Substitute.For<IDBControl>();
			var fileControlMock = Substitute.For<IFileControl>();
			var taxManager = new TaxManagementClass(fileControlMock, dbControlMock);
			string arg = "update";
			string expectedResult = "ERROR: check file - something wrong!";

			//Act
			string result = taxManager.UpdateFromFile(arg);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void GivenUpdateFromFile_WhenBadArg_ThenThrow()
		{
			//Arrange
			var dbControlMock = Substitute.For<IDBControl>();
			var fileControlMock = Substitute.For<IFileControl>();
			var taxManager = new TaxManagementClass(fileControlMock, dbControlMock);
			string arg = "test";
			string expectedResult = "ERROR: bad arguments!";

			//Act
			string result = taxManager.UpdateFromFile(arg);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}
	}
}