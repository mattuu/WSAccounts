using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Accounts.Entities;

namespace WS.Accounts.Import
{
    public class SpreadsheetTransactionReader : ITransactionReader
    {
        private ICollection<Account> _accounts;
        private IEnumerable<Transaction> _transactions;

        public void Import(Stream inputStream)
        {
            // Getting the complete workbook... 
            var workbook = new HSSFWorkbook(inputStream);

            ReadTransactionsFromPaid(workbook);
            
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accounts;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public int GetProgress()
        {
            throw new NotImplementedException();
        }

        private void ReadAccountsFromPaid(ISheet sheet)
        {
            var i = 9; // row index..
            var j = 3; // column index..
            var factory = new AccountFactory();

            var cells = sheet.GetRow(i).Cells;

            var index = j;
            while (cells[index] != null)
            {
                var name = cells[index].StringCellValue;
                _accounts.Add(factory.Create(name));
            }
        }

        private void ReadTransactionsFromPaid(IWorkbook workbook)
        {
            var sheet = workbook.GetSheet(SheetNames.Paid);
            ReadAccountsFromPaid(sheet);

            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row != null) //null is when the row only contains empty cells 
                {
                    var paidRow = PaidRow.Create(row);                    
                }
            }
        }

        //private void ReadSpreadsheet(Stream inputStream)
        //{
        //    var bw = new BackgroundWorker();

        //    bw.RunWorkerAsync(
        //}

    }

}
