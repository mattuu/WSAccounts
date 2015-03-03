using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WS.Accounts.DataAccess;

namespace WS.Accounts.Import.Tests
{
    [TestClass]
    public class SpreadsheetTransactionReaderTests
    {
        [TestMethod]
        public void ReadTest()
        {
            const string path = @"C:\temp\stuff.xls";

            Assert.IsTrue(File.Exists(path));

            IAccountStore accountStore = new InMemoryAccountStore();

            var accountFactory = new PaidRowAccountFactory(accountStore, 1);

            SpreadsheetTransactionReader reader;
            using (var file = File.Open(path, FileMode.Open))
            {
                reader = new SpreadsheetTransactionReader(file);
                reader.AddTransactionReader(new PaidSheetTransactionReader(accountFactory));
                reader.Import();
            }

            Assert.IsNotNull(reader);
            Assert.AreEqual(2, accountStore.GetAll().Count());
        }
    }
}