using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace WS.Accounts.Import.Tests
{
    [TestClass]
    public class SpreadsheetTransactionReaderTests
    {
        [TestMethod]
        public void ReadTest()
        {
            var reader = new SpreadsheetTransactionReader();

            var file = File.Open(@"C:\temp\accounts.xls", FileMode.Open);
            reader.Import(file);


        }
    }
}
